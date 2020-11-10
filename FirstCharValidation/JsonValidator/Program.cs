using System;
using StringValidation;

namespace JsonValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = new Value();
            string text = System.IO.File.ReadAllText(@"C:\Users\Adrian\Desktop\json1.txt");

            if (pattern.Match(text).Success())
            {
                Console.WriteLine("Text is a valid JSON text.");
            }
            else
            {
                Console.WriteLine("Text is not a valid JSON text.");
            }
        }
    }
}
