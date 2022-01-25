using System.Globalization;
using System.Numerics;

namespace OpenSeaClient
{
    internal static class BigIntegerExtensions
    {
        internal static int NumberOfDigits(this BigInteger value)
        {
            return (value * value.Sign).ToString().Length;
        }

        internal static BigInteger ParseInvariant(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            return BigInteger.Parse(value, CultureInfo.InvariantCulture);
        }
    }
}
