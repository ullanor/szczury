using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace szczury
{
    static class MultiCounterClass
    {
        static bool checkIfFileExists()
        {
            string path = "path to downloaded file";
            if (!File.Exists(path))
            {
                Console.WriteLine("Error - cannot find the file!\n");
                return false;
            }
            return true;
        }
        public static void CountLetters()
        {
            //if (!checkIfFileExists())
            //    return;
            string test = "abbcc daba grabaz!! 123? A6783!";
            int lettersCount = test.Count(char.IsLetter);
            Console.WriteLine("There are {0} letters in the file\n", lettersCount);
        }

        //locate your static methods here to make app looks cleaner ;)

        //TODO
    }
}
