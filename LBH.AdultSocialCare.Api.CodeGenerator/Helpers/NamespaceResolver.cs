using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LBH.AdultSocialCare.Api.CodeGenerator.Helpers
{
    public static class NamespaceResolver
    {
        public static IEnumerable<string> FindNamespaces(IEnumerable<SyntaxTree> syntaxForrest, params string[] targetNamespaces)
        {
            return syntaxForrest
                .Select(tree => tree.GetRoot()              // 1. select all namespaces
                    .DescendantNodes()
                    .OfType<NamespaceDeclarationSyntax>()
                    .First().Name.ToFullString())
                .Where(@namespace => targetNamespaces       // 2. filter out target namespaces only
                    .Any(targetNamespace => @namespace.StartsWith($"LBH.AdultSocialCare.Api.V1.{targetNamespace}")))
                .Select(@namespace => @namespace.Trim())
                .Distinct().ToList();
        }
    }
}
