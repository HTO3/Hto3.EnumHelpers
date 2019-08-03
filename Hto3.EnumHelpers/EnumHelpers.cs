using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Hto3.EnumHelpers
{
    public static class EnumHelpers
    {
        /// <summary>
        /// Gets a dictionary containing in its keys the enums and their value, the description text of the enum. The enum must be decorated with <i>DescriptionAttribute</i>.
        /// </summary>
        /// <typeparam name="T">The enum type</typeparam>
        /// <returns></returns>
#if NET40
        public static IDictionary<T, String> GetMembers<T>() where T : struct
#else
        public static IReadOnlyDictionary<T, String> GetMembers<T>() where T : struct
#endif
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException($"The type '{typeof(T).FullName}' is not an enum.");

            var internalDic = new Dictionary<T, String>();

            foreach (var enumElement in Enum.GetNames(typeof(T)))
            {
                var enumValue = (T)Enum.Parse(typeof(T), enumElement);
                var memberInfo = typeof(T).GetMember(enumElement).First();
                var descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(memberInfo, typeof(DescriptionAttribute));
                internalDic.Add(enumValue, descriptionAttribute?.Description ?? enumElement);
            }

            return internalDic;
        }
        /// <summary>
        /// Parse a string as an enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T Parse<T>(String value, Boolean ignoreCase = false) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException($"The type '{typeof(T).FullName}' is not an enum.");

            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }
        /// <summary>
        /// Get the enum description. The enum should be decorated with <i>DescriptionAttribute</i> to get a fancy string, otherwise you will get the enum name.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String GetDescription(this Enum value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var fieldInfo = value
                .GetType()
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .FirstOrDefault(m => value.Equals(m.GetValue(null)));

            if (fieldInfo == null)
                return null;

            var descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

            return descriptionAttribute?.Description ?? value.ToString();
        }
    }
}
