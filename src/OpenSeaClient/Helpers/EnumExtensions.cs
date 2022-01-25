using System.ComponentModel;
using System.Reflection;

namespace OpenSeaClient
{
    internal static class EnumExtensions
    {
        internal static string? GetDescription<T>(this T? value)
            where T : struct
        {
            Type type = typeof(T);

            if (!type.IsEnum)
            {
                throw new InvalidOperationException("The type parameter T must be an enum type.");
            }

            if (value == null)
            {
                return null;
            }

            if (!Enum.IsDefined(type, value))
            {
                throw new InvalidEnumArgumentException("value", Convert.ToInt32(value), type);
            }

            var stringValue = value.ToString();

            if (stringValue == null)
            {
                return stringValue;
            }

            var fi = type.GetField(stringValue, BindingFlags.Static | BindingFlags.Public);

            return fi?.GetCustomAttributes<DescriptionAttribute>()?.FirstOrDefault()?.Description;
        }
    }
}
