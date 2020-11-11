using System;
using System.IO;
using StringValidation;

namespace JsonValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            Value pattern = new Value();
            ArgumentsCheck(args);

            for (int i = 0; i < args.Length; i++)
            {
                if (!File.Exists(args[i]))
                {
                    Console.WriteLine(args[i] + "\nThe path you entered is not valid.");
                    break;
                }

                string text = System.IO.File.ReadAllText(args[i]);
                if (pattern.Match(text).Success() && pattern.Match(text).RemainingText() == "")
                {
                    Console.WriteLine(args[i].Substring(args[i].LastIndexOf('\\') + 1) + " is a valid JSON text.");
                }
                else
                {
                    Console.WriteLine(args[i].Substring(args[i].LastIndexOf('\\') + 1) +  " is not a valid JSON text.");
                }
            }
        }

        private static void ArgumentsCheck(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter at least one path in command line.");
            }
        }
    }
}