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

            if (input.Contains('.') && !EndsWithDot(input))
            {
                return NumberIsOnlyDigits(input.Substring(0, input.IndexOf('.'))) &&
                        IsAValidNumber(input.Substring(input.IndexOf('.') + 1));
            }

            return input[0] != '0' && IsValidInteger(input) && !EndsWithDot(input);
        }

        private static bool IsValidInteger(string input)
        {
            if (input[0] == '-' || input[0] == '+')
            {
                return IsAValidNumber(input.Substring(1));
            }

            return IsAValidNumber(input);
        }

        private static bool NumberIsOnlyDigits(string numberToCheck)
        {
            for (int i = 0; i < numberToCheck.Length; i++)
            {
                if (!CharIsInRange(numberToCheck[i], '0', '9'))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsAValidNumber(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (IsExponent(input[i]) && IsValidExponent(input.Substring(i)))
                {
                    return true;
                }

                if (!CharIsInRange(input[i], '0', '9'))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsExponent(char c)
        {
            return c == 'e' || c == 'E';
        }

        private static bool IsValidExponent(string exponent)
        {
            if (exponent.Length <= 1 ||
                !CharIsInRange(exponent[exponent.Length - 1], '0', '9'))
            {
                return false;
            }

            int exponentCount = 0;
            for (int i = 0; i < exponent.Length; i++)
            {
                if (!IsExponent(exponent[i]) &&
                    exponent[i] != '+' && exponent[i] != '-' &&
                    !CharIsInRange(exponent[i], '0', '9'))
                {
                    return false;
                }

                if (IsExponent(exponent[i]))
                {
                    exponentCount++;
                }
            }

            return exponentCount == 1;
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
    }
}