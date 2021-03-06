using System;
using System.Globalization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.IO;
using System.Text;

namespace LBH.AdultSocialCare.Api.CodeGenerator.Helpers
{
    public static class SourceCodeWriter
    {
        public static void Write(string code, string path)
        {
            var formattedCode = Format(code);
            var previousVersion = File.ReadAllText(path, Encoding.ASCII);

            // sometimes unchanged files still have modification from git POV, avoid this
            // for some reason line endings in file sometimes switch to CRLF
            if (String.Compare(formattedCode, previousVersion, CultureInfo.CurrentCulture, CompareOptions.IgnoreSymbols) != 0)
            {
                File.WriteAllText(path, formattedCode, Encoding.ASCII);
            }
        }

        private static string Format(string code)
        {
            var sourceTree = CSharpSyntaxTree.ParseText(code);
            var root = sourceTree.GetRoot().NormalizeWhitespace();

            return root.ToFullString() + "\n";
        }
    }
}
