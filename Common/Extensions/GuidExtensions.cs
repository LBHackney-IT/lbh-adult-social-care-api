using System;

namespace Common.Extensions
{
    public static class GuidExtensions
    {
        public static bool IsEmpty(this Guid? guid)
        {
            return guid is null || guid == Guid.Empty;
        }
    }
}
