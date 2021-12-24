using System;

namespace Common.Extensions
{
    public static class GuidExtensions
    {
        public static bool IsEmpty(this Guid guid) => guid == Guid.Empty;

        public static bool IsEmpty(this Guid? guid) => guid is null || guid == Guid.Empty;
    }
}
