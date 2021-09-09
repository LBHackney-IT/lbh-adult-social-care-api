using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args[0];

            var generators = new List<IGenerator>
            {
                new MappingsGenerator()
            };

            foreach (var generator in generators)
            {
                generator.Run(path);
            }
        }
    }
}
