
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountInnerLettersInWords
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0) 
            {
                Console.Error.WriteLine("No Command Line argument found!");
                Console.WriteLine("Usage: CountLettersInWords.exe <string>");
                return 1;
            }
            CountInnerLetters letterCount = new CountInnerLetters();
            string output = letterCount.ConvertToLetterCount(args[0]);
            Console.Write(output);
            return 0;
        }
    }
}
