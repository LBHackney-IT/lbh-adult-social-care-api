using LBH.AdultSocialCare.Api.CodeGenerator.Generators;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace LBH.AdultSocialCare.Api.CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args[0];

            var syntaxForrest = Directory
                .EnumerateFiles(path, "*.cs", SearchOption.AllDirectories)
                .Select(file => CSharpSyntaxTree.ParseText(File.ReadAllText(file)))
                .ToImmutableList();

            var generators = new List<IGenerator>
            {
                new MappingsGenerator(),
                new UseCaseRegistrationGenerator(),
                new GatewayRegistrationGenerator()
            };

            foreach (var generator in generators)
            {
                generator.Run(path, syntaxForrest);
            }
        }
    }
}
