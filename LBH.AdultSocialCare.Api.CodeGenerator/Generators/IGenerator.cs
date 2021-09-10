using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace LBH.AdultSocialCare.Api.CodeGenerator.Generators
{
    public interface IGenerator
    {
        void Run(string path, IEnumerable<SyntaxTree> syntaxForrest);
    }
}
