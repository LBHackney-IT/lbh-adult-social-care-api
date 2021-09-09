using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LBH.AdultSocialCare.Api.CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args[0];
            var files = Directory.EnumerateFiles(path, "*.cs", SearchOption.AllDirectories);

            var syntaxTrees = files
                .Select(file => CSharpSyntaxTree.ParseText(File.ReadAllText(file)))
                .ToList();

            var code = new StringBuilder();

            foreach (var tree in syntaxTrees)
            {
                var sourceType = tree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();

                if (sourceType != null)
                {
                    var attributes = sourceType.AttributeLists;

                    foreach (var attribute in attributes)
                    {
                        var attributeName = attribute
                            .DescendantNodes()
                            .OfType<IdentifierNameSyntax>()
                            .FirstOrDefault()?.Identifier.Text;

                        if ("MapTo".Equals(attributeName, StringComparison.OrdinalIgnoreCase))
                        {
                            var typeofExpressions = attribute.DescendantNodes().OfType<TypeOfExpressionSyntax>();

                            foreach (var typeofExpression in typeofExpressions)
                            {
                                GenerateMappingMethod(sourceType.Identifier.Text, typeofExpression.Type.ToString(), code);
                            }
                        }
                    }
                }
            }

            File.WriteAllText(args[1], code.ToString());
        }

        private static void GenerateMappingMethod(string sourceTypeName, string targetTypeName, StringBuilder codeBuilder)
        {
            var entityName = GetEntityName(sourceTypeName, targetTypeName);
            var postfix = GetPostfix(entityName, targetTypeName);

            codeBuilder.Append($@"
        public static {targetTypeName} To{postfix}(this {sourceTypeName} input)
        {{
            return _mapper.Map<{targetTypeName}>(input);  
        }}");
            codeBuilder.AppendLine();
        }

        // Assume that all DTO types are named based on entity name with some prefix and / or postfix
        // So entity name is the longest common substring of source and target types
        private static string GetEntityName(string name1, string name2)
        {
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
    }
}
