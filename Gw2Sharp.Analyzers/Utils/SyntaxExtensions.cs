using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Gw2Sharp.Analyzers.Utils
{
    internal static class SyntaxExtensions
    {
        public static SyntaxList<UsingDirectiveSyntax> AddUnreferencedUsingDirectives(this SyntaxList<UsingDirectiveSyntax> usings, IEnumerable<UsingDirectiveSyntax> newUsings)
        {
            var filtered = newUsings.Where(u => !usings.Any(u2 => u.Name.ToFullString() == u2.Name.ToFullString()));
            return usings.AddRange(filtered);
        }
    }
}
