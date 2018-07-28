using System.Collections.Immutable;
using System.Linq;
using Gw2Sharp.Analyzers.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Gw2Sharp.Analyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ApiEndpointClientImplementationAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = nameof(ApiEndpointClientImplementationAnalyzer);
        private static readonly DiagnosticDescriptor rule = new DiagnosticDescriptor(
            DiagnosticId,
            new LocalizableResourceString(nameof(Resources.ApiEndpointClientImplementationAnalyzerTitle), Resources.ResourceManager, typeof(Resources)),
            new LocalizableResourceString(nameof(Resources.ApiEndpointClientImplementationAnalyzerFormat), Resources.ResourceManager, typeof(Resources)),
            "Gw2Sharp",
            DiagnosticSeverity.Info,
            true,
            new LocalizableResourceString(nameof(Resources.ApiEndpointClientImplementationAnalyzerDescription), Resources.ResourceManager, typeof(Resources))
        );

        private const string BaseEndpointClient = nameof(BaseEndpointClient);
        private const string IClient = nameof(IClient);


        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(rule);

        public override void Initialize(AnalysisContext context) => context.RegisterSymbolAction(Analyze, SymbolKind.NamedType);

        private static void Analyze(SymbolAnalysisContext context)
        {
            var typeSymbol = (INamedTypeSymbol)context.Symbol;

            if (typeSymbol.BaseType?.Name != BaseEndpointClient)
                return; // Doesn't implement the base class we're looking for

            var mainInterface = typeSymbol.Interfaces.FirstOrDefault(s => s.Interfaces.Any(s_ => s_.AllInterfaces.Any(s__ => s__.Name == IClient)));
            if (mainInterface == null)
                return; // Doesn't have an interface that has any interfaces that implement IClient

            var endpointInterfaces = mainInterface.Interfaces.Where(s => s.AllInterfaces.Any(s_ => s_.Name == IClient)).ToList();

            var classMethods = typeSymbol.GetMembers().Where(s => s.Kind == SymbolKind.Method).Cast<IMethodSymbol>();
            var endpointMethods = endpointInterfaces.SelectMany(s => s.GetMembers().Where(s_ => s_.Kind == SymbolKind.Method)).Cast<IMethodSymbol>();
            if (endpointMethods.All(em => classMethods.Any(
                cm => em.Name == cm.Name && em.Parameters
                    .Select((emp, i) => i < cm.Parameters.Length && emp.Type.GetTypeName() == cm.Parameters[i].Type.GetTypeName())
                    .All(b => b))))
                return;

            var diagnostic = Diagnostic.Create(rule,
                typeSymbol.Locations[0],
                string.Join(", ", endpointInterfaces.Select(s => s.Name)));
            context.ReportDiagnostic(diagnostic);
        }
    }
}
