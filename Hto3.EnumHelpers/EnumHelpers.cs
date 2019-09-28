using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Hto3.EnumHelpers
{
    /// <summary>
    /// Enum helpers
    /// </summary>
    public static class EnumHelpers
    {
        /// <summary>
        /// Gets a dictionary containing in its keys the enums and their value, the description text of the enum. The enum should be decorated with <i>DescriptionAttribute</i>.
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
        /// <typeparam name="T">The enum type</typeparam>
        /// <param name="value">A string that represent an enum member</param>
        /// <param name="ignoreCase">If true, case insensitive member identification</param>
        /// <returns></returns>
        public static T Parse<T>(String value, Boolean ignoreCase = false) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException($"The type '{typeof(T).FullName}' is not an enum.");

            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }
        /// <summary>
        /// Get the enum description. The enum should be decorated with <i>DescriptionAttribute</i> to get a fancy description, otherwise you will get the enum name.
        /// </summary>
        /// <param name="value">The enum item</param>
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
        /// <summary>
        /// Get all combinated flag of a flagable enum.
        /// </summary>
        /// <typeparam name="T">The enum type</typeparam>
        /// <param name="value">A flagable enum</param>
        /// <returns></returns>
        public static IEnumerable<T> GetCombinatedFlags<T>(this T value) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException($"The type '{typeof(T).FullName}' is not an enum.");
            if (!typeof(T).GetCustomAttributes(false).Any(ca => typeof(FlagsAttribute).IsInstanceOfType(ca)))
                throw new ArgumentException($"The type '{typeof(T).FullName}' is not a flagable enum.");

            var flagCombination = Convert.ToInt64(value, CultureInfo.InvariantCulture);

            foreach (var item in Enum.GetValues(typeof(T)))
            {
                var itemAsNumber = Convert.ToInt64(item, CultureInfo.InvariantCulture);

                if (itemAsNumber == (flagCombination & itemAsNumber))
                {
                    yield return (T)item;
                }
            }
        }
    }
}
