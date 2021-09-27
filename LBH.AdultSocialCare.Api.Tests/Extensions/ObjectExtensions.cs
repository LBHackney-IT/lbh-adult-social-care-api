namespace LBH.AdultSocialCare.Api.Tests.Extensions
{
    public static class ObjectExtensions
    {
        public static object DeepCopy(this object obj)
        {
            return FastDeepCloner.DeepCloner.Clone(obj);
        }

        public static T DeepCopy<T>(this T original)
        {
            return (T) DeepCopy((object) original);
        }
    }
}
