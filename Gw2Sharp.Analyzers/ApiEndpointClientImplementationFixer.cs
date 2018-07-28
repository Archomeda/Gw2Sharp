// I hate writing this. Why is Roslyn so damn complicated.
// This will probably break on several occasions, but right now I'm done with this crap.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gw2Sharp.Analyzers.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;

namespace Gw2Sharp.Analyzers
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ApiEndpointClientImplementationFixer)), Shared]
    public class ApiEndpointClientImplementationFixer : CodeFixProvider
    {
        private readonly string title = new LocalizableResourceString(nameof(Resources.ApiEndpointClientImplementationAnalyzerFix), Resources.ResourceManager, typeof(Resources)).ToString();
        private const string IClient = nameof(IClient);
        private const string IIdentifiable = nameof(IIdentifiable);
        private const string IAllExpandableClient = nameof(IAllExpandableClient);
        private const string IBlobClient = nameof(IBlobClient);
        private const string IBulkExpandableClient = nameof(IBulkExpandableClient);
        private const string IPaginatedClient = nameof(IPaginatedClient);
        private readonly string[] interfaceMethods = new[] { "All", "Ids", "Get", "Many", "Page", "AllWithResponse", "IdsWithResponse", "GetWithResponse", "ManyWithResponse", "PageWithResponse" };

        public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(ApiEndpointClientImplementationAnalyzer.DiagnosticId);

        public sealed override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
            var diagnostic = context.Diagnostics.First();
            var diagnosticSpan = diagnostic.Location.SourceSpan;

            var declaration = root.FindToken(diagnosticSpan.Start).Parent.AncestorsAndSelf().OfType<ClassDeclarationSyntax>().First();
            context.RegisterCodeFix(
               CodeAction.Create(
                   this.title,
                   c => Fix(context.Document, declaration, c),
                   this.title),
               diagnostic);
        }

        private async Task<Solution> Fix(Document document, ClassDeclarationSyntax classDecl, CancellationToken cancellationToken)
        {
            var root = (await document.GetSyntaxRootAsync(cancellationToken)) as CompilationUnitSyntax;
            var semantic = await document.GetSemanticModelAsync(cancellationToken);

            var mainInterface = classDecl.BaseList.Types
                .Select(t => semantic.GetTypeInfo(t.DescendantNodes().First()))
                .Where(t => t.Type.TypeKind == TypeKind.Interface)
                .FirstOrDefault(t => t.Type.Interfaces.Any(s_ => s_.AllInterfaces.Any(s__ => s__.Name == IClient)));

            if (mainInterface.Type == null)
                return null;

            var generator = SyntaxGenerator.GetGenerator(document);
            var methods = new List<MethodDeclarationSyntax>();

            var usings = root.Usings;

            var endpointInterfaces = mainInterface.Type.Interfaces.Where(s => s.AllInterfaces.Any(s_ => s_.Name == IClient)).ToList();
            foreach (var endpointInterface in endpointInterfaces)
            {
                var members = endpointInterface.GetMembers().Where(s => this.interfaceMethods.Contains((s as IMethodSymbol)?.Name));
                foreach (var member in members)
                {
                    var methodMember = (IMethodSymbol)member;
                    if (classDecl.Members.Any(m =>
                        (m as MethodDeclarationSyntax)?.Identifier.Text == methodMember.Name &&
                        (m as MethodDeclarationSyntax).ParameterList.Parameters
                            .Select((p, i) => i < methodMember.Parameters.Length && p.Type.ToString() == methodMember.Parameters[i].Type.GetTypeName())
                            .All(b => b)))
                        continue;

                    usings = usings.AddUnreferencedUsingDirectives(methodMember.GetAllReferencedTypes().GetUsingDirectiveSyntax());

                    var methodSyntax = ((MethodDeclarationSyntax)generator.MethodDeclaration(
                        methodMember.Name,
                        methodMember.Parameters.Select(p => generator.ParameterDeclaration(p.Name, generator.TypeExpression(p.Type))),
                        methodMember.TypeParameters.Select(t => t.Name),
                        generator.TypeExpression(methodMember.ReturnType),
                        Accessibility.Public))
                        .AddModifiers(SyntaxFactory.Token(SyntaxKind.VirtualKeyword))
                        .WithBody(null)
                        .WithExpressionBody(this.CreateMethodBody(member.Name, methodMember, endpointInterface))
                        .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
                    methods.Add(methodSyntax);
                }
            }

            usings = SyntaxFactory.List(usings.OrderBy(u => u.Name.ToFullString()));

            var classReplace = classDecl.AddMembers(methods.ToArray());
            var annotation = new SyntaxAnnotation();
            var newDocument = document.WithSyntaxRoot(root
                    .ReplaceNode(classDecl, classReplace)
                    .WithUsings(usings)
                .WithAdditionalAnnotations(annotation));
            return newDocument.Project.Solution;
        }

        private ArrowExpressionClauseSyntax CreateMethodBody(string methodName, IMethodSymbol methodSymbol, INamedTypeSymbol interfaceSymbol)
        {
            SimpleNameSyntax methodNameSyntax;
            switch (interfaceSymbol.Name)
            {
                case IAllExpandableClient:
                case IBulkExpandableClient:
                case IPaginatedClient:
                    var objectType = interfaceSymbol.TypeArguments.FirstOrDefault();
                    var idType = objectType.Interfaces.FirstOrDefault(s => s.Name == IIdentifiable)?.TypeArguments.FirstOrDefault();
                    methodNameSyntax = SyntaxFactory.GenericName($"Request{methodName}")
                        .WithTypeArgumentList(SyntaxFactory.TypeArgumentList(
                            SyntaxFactory.SeparatedList(new[] { objectType, idType }.Select(t => SyntaxFactory.ParseTypeName(t.GetTypeName())))
                        ));
                    break;
                default:
                    methodNameSyntax = SyntaxFactory.IdentifierName($"Request{methodName}");
                    break;
            }

            return SyntaxFactory.ArrowExpressionClause(SyntaxFactory.InvocationExpression(
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.ThisExpression(),
                        methodNameSyntax
                    )
                ).WithArgumentList(SyntaxFactory.ArgumentList(
                    SyntaxFactory.SeparatedList(
                        methodSymbol.Parameters.Select(p => SyntaxFactory.Argument(SyntaxFactory.IdentifierName(p.Name)))
                    )
                ))
            );
        }
    }
}
