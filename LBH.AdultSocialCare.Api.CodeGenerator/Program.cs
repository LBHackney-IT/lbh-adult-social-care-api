using System;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LBH.AdultSocialCare.Api.CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\Documents\projects\innowise\HASC\lbh-adult-social-care-api\LBH.AdultSocialCare.Api\V1\Domain"; //args[0];

            var files = Directory.EnumerateFiles(path, "*.cs", SearchOption.AllDirectories);

            var syntaxTrees = files
                .Select(file => CSharpSyntaxTree.ParseText(File.ReadAllText(file)))
                .ToList();

            foreach (var tree in syntaxTrees)
            {
                var properties = tree.GetRoot().DescendantNodes().OfType<PropertyDeclarationSyntax>();

                foreach (var property in properties)
                {
                    var attributes = property.AttributeLists;

                    foreach (var attribute in attributes)
                    {
                        var attributeName = attribute
                            .DescendantNodes()
                            .OfType<IdentifierNameSyntax>()
                            .FirstOrDefault()?.Identifier.Text;

                        if ("MapTo".Equals(attributeName, StringComparison.OrdinalIgnoreCase))
                        {
                        }
                    }

                    if (attributes.Any())
                    {
                        var arguments = attributes[0].DescendantNodes().OfType<AttributeArgumentSyntax>();



                        foreach (var argument in arguments)
                        {
                            var content = argument.Expression.ToString();
                            Console.WriteLine("Hello world" + content);
                        }
                    }
                }
            }
        }
    }
}
