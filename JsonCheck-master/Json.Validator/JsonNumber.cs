using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (StringIsNullOrEmptyCheck(input))
            {
                return false;
            }

            bool isFraction = ContainsChar(input, '.');
            bool hasExponent = ContainsChar(input, 'e') || ContainsChar(input, 'E');
            if (isFraction && !EndsWithDot(input))
            {
                return hasExponent ? ExponentIsValid(input) : IsValidFraction(input);
            }
            else if (hasExponent)
            {
                return IsAValidNumber(input) && ExponentIsValid(input) && !EndsWithDot(input);
            }

            return IsAValidNumber(input) && !EndsWithDot(input);
        }

        private static bool IsAValidNumber(string input)
        {
            char[] validChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '+', '.', 'e', 'E' };
            if (input.Length == 1 && Array.IndexOf(validChars, input[0]) != -1)
            {
                return true;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[0] == '0' || Array.IndexOf(validChars, input[i]) == -1)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsValidFraction(string input)
        {
            char[] validChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '+', '.', 'e', 'E' };
            int fractionCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (Array.IndexOf(validChars, input[i]) == -1)
                {
                    return false;
                }

                if (input[i] == '.')
                {
                    fractionCount++;
                }
            }

            return fractionCount == 1;
        }

        private static bool ExponentIsValid(string input)
        {
            int exponentCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'e' || input[i] == 'E')
                {
                    if (!ExponentIsComplete(input.Substring(i)))
                    {
                        return false;
                    }

                    exponentCount++;
                }
            }

            return IsValidFraction(input) ?
                exponentCount == 1 && ExponentIsAfterTheFraction(input) :
                exponentCount == 1;
        }

        private static bool ExponentIsComplete(string input)
        {
            return input.Length > 1 && input[input.Length - 1] >= '0' && input[input.Length - 1] <= '9';
        }

        private static bool ExponentIsAfterTheFraction(string input)
        {
            return GetIndex(input, 'e') > GetIndex(input, '.') ||
                GetIndex(input, 'E') > GetIndex(input, '.');
        }

        private static bool EndsWithDot(string input)
        {
            return input[input.Length - 1] == '.';
        }

        private static bool StringIsNullOrEmptyCheck(string input)
        {
            return string.IsNullOrEmpty(input);
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

        private static int GetIndex(string input, char c)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == c)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
