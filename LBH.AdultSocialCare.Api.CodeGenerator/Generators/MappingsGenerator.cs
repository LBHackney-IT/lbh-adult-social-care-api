using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LBH.AdultSocialCare.Api.CodeGenerator.Generators
{
    public class MappingsGenerator : IGenerator
    {
        public void Run(string path, IEnumerable<SyntaxTree> syntaxForrest)
        {
            var mappingExtensionBuilder = new StringBuilder();
            var mappingProfileBuilder = new StringBuilder();

            WriteUsingList(path, mappingExtensionBuilder);
            WriteUsingList(path, mappingProfileBuilder);

            WriteExtensionsClassHeader(mappingExtensionBuilder);
            WriteProfileClassHeader(mappingProfileBuilder);

            GenerateMappings(syntaxForrest, mappingExtensionBuilder, mappingProfileBuilder);

            WriteExtensionsClassFooter(mappingExtensionBuilder);
            WriteProfileClassFooter(mappingProfileBuilder);

            Directory.CreateDirectory(Path.Combine(path, "Generated"));

            File.WriteAllText(
                Path.Combine(path, "Generated", "MappingExtensions.cs"),
                CodeFormatter.Format(mappingExtensionBuilder), Encoding.ASCII);
            File.WriteAllText(
                Path.Combine(path, "Generated", "GeneratedMappingProfile.cs"),
                CodeFormatter.Format(mappingProfileBuilder), Encoding.ASCII);
        }

        private static void GenerateMappings(IEnumerable<SyntaxTree> syntaxForrest, StringBuilder mappingExtensionBuilder, StringBuilder mappingProfileBuilder)
        {
            var registeredMappings = new HashSet<KeyValuePair<string, string>>();

            foreach (var syntaxTree in syntaxForrest)
            {
                var sourceType = syntaxTree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();

                if (sourceType != null)
                {
                    var attributes = sourceType.AttributeLists;

                    foreach (var attribute in attributes)
                    {
                        var attributeName = attribute
                            .DescendantNodes()
                            .OfType<IdentifierNameSyntax>()
                            .FirstOrDefault()?.Identifier.Text;

                        if ((attributeName == "MapTo") || (attributeName == "MapListTo"))
                        {
                            var typeofExpressions = attribute.DescendantNodes().OfType<TypeOfExpressionSyntax>();

                            foreach (var typeofExpression in typeofExpressions)
                            {
                                var sourceTypeName = sourceType.Identifier.Text;
                                var targetTypeName = typeofExpression.Type.ToString();

                                switch (attributeName)
                                {
                                    case "MapTo":
                                        WriteObjectMappingMethod(sourceTypeName, targetTypeName, mappingExtensionBuilder);
                                        WriteObjectMappingMethod(targetTypeName, sourceTypeName, mappingExtensionBuilder);
                                        break;
                                    case "MapListTo":
                                        WriteListMappingMethod(sourceTypeName, targetTypeName, mappingExtensionBuilder);
                                        WriteListMappingMethod(targetTypeName, sourceTypeName, mappingExtensionBuilder);
                                        break;
                                }

                                var mappingPair = new KeyValuePair<string, string>(sourceTypeName, targetTypeName);

                                if (!registeredMappings.Contains(mappingPair))
                                {
                                    // to avoid duplicate registrations for entities marked with both MapTo and MapListTo
                                    WriteCreateMapStatement(sourceTypeName, targetTypeName, mappingProfileBuilder);
                                    registeredMappings.Add(mappingPair);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void WriteObjectMappingMethod(string sourceTypeName, string targetTypeName, StringBuilder codeBuilder)
        {
            var entityName = GetEntityName(sourceTypeName, targetTypeName);
            var postfix = GetPostfix(entityName, targetTypeName);

            codeBuilder.AppendLine($@"
                public static {targetTypeName} To{postfix}(this {sourceTypeName} input)
                {{
                    return _mapper.Map<{targetTypeName}>(input);  
                }}");
        }

        private static void WriteListMappingMethod(string sourceTypeName, string targetTypeName, StringBuilder codeBuilder)
        {
            var entityName = GetEntityName(sourceTypeName, targetTypeName);
            var postfix = GetPostfix(entityName, targetTypeName);

            codeBuilder.AppendLine($@"
                public static IEnumerable<{targetTypeName}> To{postfix}(this IEnumerable<{sourceTypeName}> input)
                {{
                    return _mapper.Map<IEnumerable<{targetTypeName}>>(input);  
                }}");
        }

        private static void WriteCreateMapStatement(string sourceTypeName, string targetTypeName, StringBuilder codeBuilder)
        {
            codeBuilder.Append($"CreateMap<{sourceTypeName}, {targetTypeName}>().ReverseMap();");
        }

        private static string GetEntityName(string name1, string name2)
        {
            // Assume that all DTO types are named based on entity name with some prefix and / or postfix
            // So entity name is the longest common substring of source and target types

            // Algorithm is borrowed from https://www.programmingalgorithms.com/algorithm/longest-common-substring/
            if (string.IsNullOrEmpty(name1) || string.IsNullOrEmpty(name2))
            {
                return String.Empty;
            }

            var num = new int[name1.Length, name2.Length];

            var maxlen = 0;
            var lastSubsBegin = 0;

            var subStringBuilder = new StringBuilder();

            for (var i = 0; i < name1.Length; i++)
            {
                for (var j = 0; j < name2.Length; j++)
                {
                    if (name1[i] != name2[j])
                    {
                        num[i, j] = 0;
                    }
                    else
                    {
                        if ((i == 0) || (j == 0))
                            num[i, j] = 1;
                        else
                            num[i, j] = 1 + num[i - 1, j - 1];

                        if (num[i, j] > maxlen)
                        {
                            maxlen = num[i, j];

                            int thisSubsBegin = i - num[i, j] + 1;

                            if (lastSubsBegin == thisSubsBegin)
                            {
                                subStringBuilder.Append(name1[i]);
                            }
                            else
                            {
                                lastSubsBegin = thisSubsBegin;
                                subStringBuilder.Length = 0;
                                subStringBuilder.Append(name1.Substring(lastSubsBegin, (i + 1) - lastSubsBegin));
                            }
                        }
                    }
                }
            }

            return subStringBuilder.ToString();
        }

        // determine postfix for To... method - Domain / Request / Response etc.
        private static string GetPostfix(string entityName, string targetTypeName)
        {
            if (targetTypeName == entityName)
            {
                return "Entity";
            }

            var entityNameStartIndex = targetTypeName.IndexOf(entityName, StringComparison.OrdinalIgnoreCase);
            var postfixStartIndex = entityNameStartIndex + entityName.Length;

            return targetTypeName[postfixStartIndex..];
        }

        private static void WriteUsingList(string path, StringBuilder codeBuilder)
        {
            // Add all known namespaces for all types of DTOs / entities
            // assume that namespace corresponds directory name
            var extraUsings = new[] { "AutoMapper", "System", "System.Collections.Generic", "System.Linq", "HttpServices.Models.Requests", "LBH.AdultSocialCare.Api.V1.Infrastructure.Entities" };

            foreach (var @using in extraUsings)
            {
                codeBuilder.AppendLine($"using {@using};");
            }

            var directories = new List<string>();

            directories.AddRange(Directory.GetDirectories(Path.Combine(path, "Boundary"), "*", SearchOption.AllDirectories));
            directories.AddRange(Directory.GetDirectories(Path.Combine(path, "Domain"), "*", SearchOption.AllDirectories));
            directories.AddRange(Directory.GetDirectories(Path.Combine(path, @"Infrastructure\Entities"), "*", SearchOption.AllDirectories));

            foreach (var directory in directories)
            {
                var @using = directory.Remove(0, path.Length).Replace('\\', '.');

                codeBuilder.AppendLine($"using LBH.AdultSocialCare.Api.V1.{@using};");
            }
        }

        private static void WriteExtensionsClassHeader(StringBuilder codeBuilder)
        {
            codeBuilder.AppendLine(@"
                namespace LBH.AdultSocialCare.Api.V1.Factories
                {
                    public static partial class MappingExtensions
                    {
                        private static IMapper _mapper { get; set; }

                        public static void Configure(IMapper mapper)
                        {
                            _mapper = mapper;
                        }");
        }

        private static void WriteProfileClassHeader(StringBuilder codeBuilder)
        {
            codeBuilder.AppendLine(@"
                namespace LBH.AdultSocialCare.Api.V1.Profiles
                {
                    public class GeneratedMappingProfile : Profile
                    {
                        public GeneratedMappingProfile()
                        {");
        }

        private static void WriteExtensionsClassFooter(StringBuilder codeBuilder)
        {
            codeBuilder.AppendLine(@"
                }
            }");
        }

        private static void WriteProfileClassFooter(StringBuilder codeBuilder)
        {
            codeBuilder.AppendLine(@"
                    }
                }
            }");
        }
    }
}
