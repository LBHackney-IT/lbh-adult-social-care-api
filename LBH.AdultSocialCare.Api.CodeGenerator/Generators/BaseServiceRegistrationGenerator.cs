using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LBH.AdultSocialCare.Api.CodeGenerator.Generators
{
    public abstract class BaseServiceRegistrationGenerator : IGenerator
    {
        protected abstract string SourceNamespace { get; }
        protected abstract string SourceDirectory { get; }
        protected abstract string ClassNamePostfix { get; }
        protected abstract string GeneratedFileName { get; }

        public void Run(string path, IEnumerable<SyntaxTree> syntaxForrest)
        {
            var codeBuilder = new StringBuilder();

            WriteUsingList(path, codeBuilder);
            WriteClassHeader(codeBuilder);

            var useCaseSyntaxForrest = syntaxForrest
                .Where(tree => tree.GetRoot()
                    .DescendantNodes().OfType<NamespaceDeclarationSyntax>()
                    .First().Name.ToString().Contains(SourceNamespace));

            foreach (var syntaxTree in useCaseSyntaxForrest)
            {
                var sourceType = syntaxTree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();

                if (sourceType != null)
                {
                    var className = sourceType.Identifier.Text;

                    if (className.EndsWith(ClassNamePostfix))
                    {
                        codeBuilder.Append($"services.AddScoped<I{className}, {className}>();");
                    }
                }
            }

            WriteClassFooter(codeBuilder);

            File.WriteAllText(
                Path.Combine(path, "Generated", GeneratedFileName),
                CodeFormatter.Format(codeBuilder), Encoding.ASCII);
        }

        private void WriteUsingList(string path, StringBuilder codeBuilder)
        {
            codeBuilder.AppendLine("using Microsoft.Extensions.DependencyInjection;");

            var useCaseDirectories = Directory.GetDirectories(Path.Combine(path, SourceDirectory), "*", SearchOption.AllDirectories);

            foreach (var directory in useCaseDirectories)
            {
                var @using = directory.Remove(0, path.Length).Replace('\\', '.');

                codeBuilder.AppendLine($"using LBH.AdultSocialCare.Api.V1.{@using};");
            }
        }

        private void WriteClassHeader(StringBuilder codeBuilder)
        {
            codeBuilder.AppendLine($@"
                namespace LBH.AdultSocialCare.Api.V1.Extensions
                {{
                    public static class {ClassNamePostfix}Extensions
                    {{
                        public static void Register{ClassNamePostfix}s(this IServiceCollection services)
                        {{");
        }

        private static void WriteClassFooter(StringBuilder codeBuilder)
        {
            codeBuilder.AppendLine(@"
                    }
                }
            }");
        }
    }
}
