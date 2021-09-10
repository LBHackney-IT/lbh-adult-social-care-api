using System;

namespace LBH.AdultSocialCare.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class GenerateListMappingForAttribute : Attribute
    {
        private Type[] _mappingTargets;

        public GenerateListMappingForAttribute(params Type[] mappingTargets)
        {
            _mappingTargets = mappingTargets;
        }
    }
}

