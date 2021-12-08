using FastDeepCloner;

namespace LBH.AdultSocialCare.TestFramework.Extensions
{
    public static class ObjectExtensions
    {
        public static object DeepCopy(this object obj, CloneLevel level)
        {
            return obj.Clone(new FastDeepClonerSettings { CloneLevel = level });
        }

        public static T DeepCopy<T>(this T original, CloneLevel level = CloneLevel.Hierarki)
        {
            return (T) DeepCopy((object) original, level);
        }
    }
}
