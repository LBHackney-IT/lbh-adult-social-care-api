using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.CodeGenerator.Generators
{
    public interface IGenerator
    {
        void Run(string path, IEnumerable<SyntaxTree> syntaxForrest);
    }
}
