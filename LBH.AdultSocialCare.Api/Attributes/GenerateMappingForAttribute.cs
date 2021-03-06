using System;

namespace LBH.AdultSocialCare.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class GenerateMappingForAttribute : Attribute
    {
        private Type[] _mappingTargets;

        public GenerateMappingForAttribute(params Type[] mappingTargets)
        {
            _mappingTargets = mappingTargets;
        }
    }
}

