using System;
using System.IO;
using StringValidation;

namespace JsonValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            DocumentIsJson(ref args);
        }

        public static void DocumentIsJson(ref string[] args)
        {
            Value pattern = new Value();
            bool oneMore = true;
            while(oneMore)
            {
                AskForPath(ref args);
                if(!File.Exists(args[args.Length - 1]))
                {
                    Console.WriteLine("Document could not be found.");
                    AskForPath(ref args);
                }

                string text = System.IO.File.ReadAllText(args[args.Length - 1]);
                ValidateText(pattern, text);
                oneMore = Repeat();
            }
        }

        public static void AskForPath(ref string[] args)
        {
            do
            {
                Console.WriteLine("Please enter the path for the document you want to check.");
                Array.Resize(ref args, args.Length + 1);
                args[args.Length - 1] = Console.ReadLine();
            }
            while (args[args.Length - 1] == "");
        }

        public static void ValidateText(Value pattern, string text)
        {
            if (pattern.Match(text).Success() && pattern.Match(text).RemainingText() == "")
            {
                Console.WriteLine("This is a valid JSON text.");
            }
            else
            {
                Console.WriteLine("This is not a valid JSON text.");
            }
        }

        public static bool Repeat()
        {
            Console.WriteLine("Would you like to check another document? Answer \"yes\" / \"no\".");
            string answer = Console.ReadLine().ToLower();
            while(answer != "yes" && answer != "no")
            {
                Console.WriteLine("Would you like to check another document? Answer \"yes\" / \"no\".");
                answer = Console.ReadLine().ToLower();
            }

            return answer == "yes" ? true : false;
        }
    }
}

// string text = System.IO.File.ReadAllText(args[0]);
// @"C:\Users\Adrian\Desktop\json1.txt"
