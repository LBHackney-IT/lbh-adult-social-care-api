using System;

namespace LBH.AdultSocialCare.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class MapListToAttribute : Attribute
    {
        private Type[] _mappingTargets;

        public MapListToAttribute(params Type[] mappingTargets)
        {
            _mappingTargets = mappingTargets;
        }
    }
}

