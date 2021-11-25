using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Common.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescription(this Enum enumeration)
        {
            var attribute = GetText<DescriptionAttribute>(enumeration);

            return attribute.Description;
        }

        public static string GetDisplayName(this Enum enumeration)
        {
            if (enumeration is null) return string.Empty;

            var attribute = GetText<DisplayAttribute>(enumeration);

            return attribute.GetName();
        }

        public static T GetText<T>(Enum enumeration) where T : Attribute
        {
            var type = enumeration.GetType();

            var memberInfo = type.GetMember(enumeration.ToString());

            if (!memberInfo.Any())
                throw new ArgumentException($"No public members for the argument '{enumeration}'.");

            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);

            if (attributes == null || attributes.Length != 1)
                throw new ArgumentException($"Can't find an attribute matching '{typeof(T).Name}' for the argument '{enumeration}'");

            return attributes.Single() as T;
        }

        public static string ConvertEnumToString(this Enum enumeration)
        {
            return enumeration.ToString();
        }

        public static bool EnumIsDefined<T>(this T enumeration, string status) where T : Enum
        {
            return Enum.IsDefined(enumeration.GetType(), status);
        }

        public static T ConvertStringToEnum<T>(this T enumeration, string status) where T : Enum
        {
            return (T) Enum.Parse(enumeration.GetType(), status, true);
        }

        public static string ConvertNumberToEnumName<T>(this T enumeration, int value) where T : Enum
        {
            return Enum.GetName(typeof(T), value);
        }

        public static T ConvertNumberToEnum<T>(this T enumeration, int value) where T : Enum
        {
            var name = Enum.GetName(typeof(T), value);
            return enumeration.ConvertStringToEnum(name);
        }

        public static int Count<T>(this T enumeration) where T : Enum
        {
            return Enum.GetNames(typeof(T)).Length;
        }
    }
}
