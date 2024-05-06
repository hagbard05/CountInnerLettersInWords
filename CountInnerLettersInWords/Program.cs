
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountInnerLettersInWords
{
    class Program
    {
        static void Main(string[] args)
        {
            CountInnerLetters letterCount = new CountInnerLetters();
            string output = letterCount.ConvertToLetterCount(args[0]);
            Console.Write(output);
        }
    }

}
