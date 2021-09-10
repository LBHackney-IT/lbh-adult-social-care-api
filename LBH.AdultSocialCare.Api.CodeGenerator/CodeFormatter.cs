using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace LBH.AdultSocialCare.Api.CodeGenerator
{
    public class CodeFormatter
    {
        public static string Format(StringBuilder codeBuilder)
        {
            var sourceTree = CSharpSyntaxTree.ParseText(codeBuilder.ToString());
            var root = sourceTree.GetRoot().NormalizeWhitespace();

            return root.ToFullString() + "\n";
        }
    }
}
