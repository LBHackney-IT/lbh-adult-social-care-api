using System;

namespace LBH.AdultSocialCare.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MapToAttribute : Attribute
    {
        private Type[] _mappingTargets;

        public MapToAttribute(params Type[] mappingTargets)
        {
            _mappingTargets = mappingTargets;
        }
    }
}

