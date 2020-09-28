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

            if (input.Length == 1 && CharIsInRange(input[0], '0', '9'))
            {
                return true;
            }

            return IsAValidNumber(input) && !EndsWithDot(input);
        }

        private static bool IsAValidNumber(string input)
        {
            const string validChars = "0123456789-+.eE";
            int numberOfExponents = CountChar(input, 'e') + CountChar(input, 'E');
            if (!input.Contains('.') && StartsWithZero(input))
            {
                return false;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (!validChars.Contains(input[i]))
                {
                    return false;
                }

                if (IsExponent(input[i]) && (input.IndexOf(input[i]) < input.IndexOf('.') || !IsValidExponent(input.Substring(i))))
                {
                    return false;
                }
            }

            return CountChar(input, '.') <= 1 && numberOfExponents <= 1;
        }

        private static bool IsExponent(char c)
        {
            return c == 'e' || c == 'E';
        }

        private static bool IsValidExponent(string exponent)
        {
            if (exponent.Length <= 1 || !CharIsInRange(exponent[exponent.Length - 1], '0', '9'))
            {
                return false;
            }

            for (int i = 1; i < exponent.Length; i++)
            {
                if (!IsExponent(exponent[i]) && exponent[i] != '+' && exponent[i] != '-' && !CharIsInRange(exponent[i], '0', '9'))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool StartsWithZero(string input)
        {
            return input[0] == '0';
        }

        private static bool EndsWithDot(string input)
        {
            return input[input.Length - 1] == '.';
        }

        private static bool StringIsNullOrEmptyCheck(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        private static bool CharIsInRange(char charToCheck, char rangeLowIndex, char rangeHighIndex)
        {
            return charToCheck >= rangeLowIndex && charToCheck <= rangeHighIndex;
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