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
            char[] escapedChars = { 'a', 'b', 'f', 'n', 'r', 't', 'u', 'v', '\\', '/', '"' };
            for (int i = 1; i < input.Length - 1; i++)
            {
                if (input[i] <= asciiControlCharsEnd)
                {
                    return true;
                }
                else if (input[i - 1] == '\\' && input[i] != ' ' && Array.IndexOf(escapedChars, input[i]) == -1)
                {
                    return true;
                }
                else if (input[i - 1] == '\\' && input[i] == 'u')
                {
                    return !IsValidHexNumber(input.Substring(i + 1));
                }
            }

            return false;
        }

        private static bool IsValidHexNumber(string input)
        {
            char[] hexChars =
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'a', 'b', 'c', 'd', 'e', 'f',
                'A', 'B', 'B', 'D', 'E', 'F'
            };
            const int validUnicodeLength = 4;

            if (input.Length < validUnicodeLength)
            {
                return false;
            }

            for (int i = 0; i < validUnicodeLength; i++)
            {
                if (Array.IndexOf(hexChars, input[i]) == -1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
