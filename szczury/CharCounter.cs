using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace szczury
{
    class CharCounter : IDisposable
    {
        string strToCount = string.Empty;
        public CharCounter(string strToCount)
        {
            this.strToCount = strToCount;
            Console.WriteLine("Creating object ...");

            var charLookup = strToCount.ToUpper().Where(char.IsLetter).ToLookup(letter => letter);

            foreach (var letter in charLookup)
                Console.WriteLine("Char:{0} Count:{1}", letter.Key, charLookup[letter.Key].Count());

            Dispose();
        }

        public void Dispose()
        {
            Console.WriteLine("\nRemoving object ...\n");
        }

        //~CharCounter()
        //{
        //    Console.WriteLine("Finalizing object!");
        //}
    }
}
