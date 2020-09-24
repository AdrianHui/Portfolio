using System;
using System.Globalization;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return IsAValidNumber(input) && !EndsWithDot(input);
        }

        public static bool IsAValidNumber(string input)
        {
            decimal result = 0;
            bool isNumber = decimal.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
            if (isNumber && Convert.ToDouble(input) % 1 > 0)
            {
                return !StringIsNullOrEmptyCheck(input) &&
                    decimal.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
            }

            return input == "0" || !StringIsNullOrEmptyCheck(input) && isNumber && !StartsWithZero(input);
        }

        private static bool EndsWithDot(string input)
        {
            return input[input.Length - 1] == '.';
        }

        private static bool StartsWithZero(string input)
        {
            return input[0] == '0';
        }

        private static bool StringIsNullOrEmptyCheck(string input)
        {
            return string.IsNullOrEmpty(input);
        }
    }
}
