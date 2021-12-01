using LBH.AdultSocialCare.Api.CodeGenerator.Generators;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace LBH.AdultSocialCare.Api.CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var targetPath = args[0];           // where *.Generated files will be created
            var sourcePaths = args.Skip(1);     // where mappable entities are located
            var syntaxForrest = new List<SyntaxTree>();

            foreach (var path in sourcePaths)
            {
                syntaxForrest.AddRange(Directory
                    .EnumerateFiles(path, "*.cs", SearchOption.AllDirectories)
                    .Select(file => CSharpSyntaxTree.ParseText(File.ReadAllText(file))));
            }

            var generators = new List<IGenerator>
            {
                new MappingsGenerator(),
                new UseCaseRegistrationGenerator(),
                new GatewayRegistrationGenerator()
            };

            foreach (var generator in generators)
            {
                generator.Run(targetPath, syntaxForrest);
            }
        }
    }
}
