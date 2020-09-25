using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return !StringIsNullOrEmptyCheck(input) && HasDoubleQuotes(input) &&
                !ContainsRestrictedCharacters(input) && !EndsWithReverseSolidus(input);
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

        private static bool ContainsRestrictedCharacters(string input)
        {
            const int asciiControlCharsEnd = 31;
            const string escapedChars = "abfnrtuv\\/\"\\ ";
            for (int i = 1; i < input.Length - 1; i++)
            {
                if (input[i] <= asciiControlCharsEnd)
                {
                    return true;
                }
                else if (input[i - 1] == '\\' && input[i] == 'u')
                {
                    return !IsValidHexNumber(input.Substring(i + 1));
                }
                else if (input[i] == '\\' && !ContainsChar(escapedChars, input[i + 1]))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsValidHexNumber(string input)
        {
            const string hexChars = "0123456789abcdefABCDEF";
            const int validUnicodeLength = 4;

            if (input.Length < validUnicodeLength)
            {
                return false;
            }

            for (int i = 0; i < validUnicodeLength; i++)
            {
                if (!ContainsChar(hexChars, input[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ContainsChar(string input, char c)
        {
            foreach (char element in input)
            {
                if (element == c)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
