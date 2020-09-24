using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return !StringIsNullOrEmptyCheck(input) && HasDoubleQuotes(input) &&
                ContainsControlCharacters(input) && !EndsWithReverseSolidus(input);
        }

        private static bool StringIsNullOrEmptyCheck(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        private static bool HasDoubleQuotes(string input)
        {
            return input.Length > 1 && input[0] == '"' && input[input.Length - 1] == '"';
        }

        private static bool EndsWithReverseSolidus(string input)
        {
            int lastChar = input.Length - 2;
            return input[lastChar] == '\\';
        }

        private static bool ContainsControlCharacters(string input)
        {
            int[] controlChars = { 9, 10, 11, 12, 13 };

            for (int i = 1; i < input.Length - 1; i++)
            {
                if (Array.IndexOf(controlChars, input[i]) != -1 || input[i - 1].ToString() + input[i].ToString() == "\\u")
                {
                    return IsValidUnicode(input, i) && IsValidEscapedChar(input, i);
                }
                else if (input[i - 1] == '\\' && input[i] >= 'a' && input[i] <= 'z')
                {
                    return IsValidEscapedChar(input, i);
                }
            }

            return true;
        }

        private static bool IsValidEscapedChar(string input, int i)
        {
            string[] validEscapedChars = { "\\a", "\\b", "\\f", "\\n", "\\r", "\\t", "\\u", "\\v" };

            return Array.IndexOf(validEscapedChars, input[i - 1].ToString() + input[i].ToString()) != -1;
        }

        private static bool IsValidUnicode(string input, int i)
        {
            return IsValidHexNumber(input.Substring(i + 1));
        }

        private static bool IsValidHexNumber(string input)
        {
            const int validUnicodeLength = 4;
            string hexNumber = "";
            int result = 0;

            if (input.Length < validUnicodeLength)
            {
                return false;
            }

            for (int i = 0; i < validUnicodeLength; i++)
            {
                hexNumber += input[i].ToString();
            }

            return int.TryParse(
                                hexNumber,
                                System.Globalization.NumberStyles.HexNumber,
                                System.Globalization.CultureInfo.CurrentCulture,
                                out result);
        }
    }
}
