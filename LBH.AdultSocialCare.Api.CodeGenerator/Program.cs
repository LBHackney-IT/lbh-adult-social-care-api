using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using LBH.AdultSocialCare.Api.CodeGenerator.Generators;
using Microsoft.CodeAnalysis.CSharp;

namespace LBH.AdultSocialCare.Api.CodeGenerator
{
    class Program
    {
        private static void killme()
        {
            killMeToo(@"D:\Documents\projects\innowise\HASC\lbh-adult-social-care-api\LBH.AdultSocialCare.Api\V1\Extensions\UseCaseExtensions.cs", @"D:\originalUseCases.txt");
            killMeToo(@"D:\Documents\projects\innowise\HASC\lbh-adult-social-care-api\LBH.AdultSocialCare.Api\V1\Extensions\GatewayExtensions.cs", @"D:\originalGateways.txt");
            killMeToo(@"D:\Documents\projects\innowise\HASC\lbh-adult-social-care-api\LBH.AdultSocialCare.Api\V1\Generated\UseCaseExtensions.cs", @"D:\newUseCases.txt");
            killMeToo(@"D:\Documents\projects\innowise\HASC\lbh-adult-social-care-api\LBH.AdultSocialCare.Api\V1\Generated\GatewayExtensions.cs", @"D:\newGateways.txt");
        }

        private static void killMeToo(string sourceFileName, string targetFileName)
        {
            var lines = File.ReadAllLines(sourceFileName);
            var result = new List<string>();

            foreach (var line in lines)
            {
                if (line.Trim().StartsWith("services.AddScoped"))
                {
                    result.Add(line.Trim());
                }
            }

            result.Sort();

            File.WriteAllLines(targetFileName, result);
        }

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

            killme();
        }
    }
}
