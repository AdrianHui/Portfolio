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
            else if (input.Contains('.') && (input.Contains('e') || input.Contains('E')))
            {
                return input.IndexOf('e') > input.IndexOf('.') || input.IndexOf('E') > input.IndexOf('.');
            }

            return IsAValidNumber(input) && !EndsWithDot(input);
        }

        private static bool IsAValidNumber(string input)
        {
            const string validChars = "0123456789-+.eE";
            int numberOfExponents = CountChar(input, 'e') + CountChar(input, 'E');
            if (input.Length == 1 && validChars.Contains(input[0]))
            {
                return true;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (StartsWithZero(input) || !validChars.Contains(input[i]))
                {
                    return false;
                }
                else if (input[i] == 'e' || input[i] == 'E')
                {
                    return ExponentIsComplete(input.Substring(i), validChars);
                }
            }

            return CountChar(input, '.') <= 1 && numberOfExponents <= 1;
        }

        private static bool ExponentIsComplete(string exponent, string validChars)
        {
            if (exponent.Length <= 1 || exponent[exponent.Length - 1] < '0' || exponent[exponent.Length - 1] > '9')
            {
                return false;
            }

            for (int i = 1; i < exponent.Length; i++)
            {
                if (!validChars.Contains(exponent[i]) || exponent[i] == 'e' || exponent[i] == 'E')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool StartsWithZero(string input)
        {
            return !input.Contains('.') && input[0] == '0';
        }

        private static bool EndsWithDot(string input)
        {
            return input[input.Length - 1] == '.';
        }

        private static bool StringIsNullOrEmptyCheck(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        private static int CountChar(string input, char c)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == c)
                {
                    count++;
                }
            }

            return count;
        }
    }
}