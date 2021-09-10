using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using LBH.AdultSocialCare.Api.CodeGenerator.Generators;
using Microsoft.CodeAnalysis.CSharp;

namespace LBH.AdultSocialCare.Api.CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\Documents\projects\innowise\HASC\lbh-adult-social-care-api\LBH.AdultSocialCare.Api\V1\"; //args[0];

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
