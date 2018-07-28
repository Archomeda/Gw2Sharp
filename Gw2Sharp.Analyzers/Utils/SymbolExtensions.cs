using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Gw2Sharp.Analyzers.Utils
{
    internal static class SymbolExtensions
    {
        public static string GetFullName(this ISymbol symbol)
        {
            var parentName = symbol.ContainingNamespace?.GetFullName();
            return !string.IsNullOrWhiteSpace(parentName) ? $"{parentName}.{symbol.Name}" : symbol.Name;
        }

        public static IEnumerable<ITypeSymbol> GetAllReferencedTypes(this ISymbol symbol)
        {
            switch (symbol)
            {
                case IArrayTypeSymbol arraySymbol:
                    return arraySymbol.ElementType.GetAllReferencedTypes();
                case IMethodSymbol methodSymbol:
                    return methodSymbol.ReturnType.GetAllReferencedTypes()
                        .Concat(methodSymbol.Parameters.SelectMany(p => p.GetAllReferencedTypes()))
                        .Concat(methodSymbol.TypeParameters.SelectMany(t => t.GetAllReferencedTypes()));
                case IParameterSymbol parameterSymbol:
                    return parameterSymbol.Type.GetAllReferencedTypes();
                    
                case ITypeParameterSymbol typeParameterSymbol:
                    return new[] { typeParameterSymbol }.Concat(typeParameterSymbol.DeclaringType.TypeParameters.SelectMany(t => t.GetAllReferencedTypes()));
                case ITypeSymbol typeSymbol:
                    if (typeSymbol.SpecialType == SpecialType.None)
                        return new[] { typeSymbol };
                    break;
            }
            return new ITypeSymbol[0];
        }

        public static UsingDirectiveSyntax GetUsingDirectiveSyntax(this ITypeSymbol symbol) =>
            SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(symbol.ContainingNamespace.GetFullName()));

        public static SyntaxList<UsingDirectiveSyntax> GetUsingDirectiveSyntax(this IEnumerable<ITypeSymbol> symbols) =>
            SyntaxFactory.List(symbols.Select(s => s.GetUsingDirectiveSyntax()));

        public static string GetTypeName(this ITypeSymbol symbol)
        {
            switch (symbol.SpecialType)
            {
                case SpecialType.System_Boolean:
                    return "bool";
                case SpecialType.System_Char:
                    return "char";
                case SpecialType.System_String:
                    return "string";
                case SpecialType.System_Int64:
                    return "long";
                case SpecialType.System_Int32:
                    return "int";
                case SpecialType.System_Int16:
                    return "short";
                case SpecialType.System_SByte:
                    return "sbyte";
                case SpecialType.System_UInt64:
                    return "ulong";
                case SpecialType.System_UInt32:
                    return "uint";
                case SpecialType.System_UInt16:
                    return "ushort";
                case SpecialType.System_Byte:
                    return "byte";
                case SpecialType.System_Single:
                    return "float";
                case SpecialType.System_Double:
                    return "double";
                default:
                    if (symbol is INamedTypeSymbol namedTypeSymbol && namedTypeSymbol.TypeArguments.Length > 0)
                        return $"{symbol.Name}<{string.Join(", ", (symbol as INamedTypeSymbol)?.TypeArguments.Select(p => p.GetTypeName()))}>";
                    else
                        return symbol.Name;
            }
        }
    }
}
