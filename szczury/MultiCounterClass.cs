using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;

namespace szczury
{
    static class MultiCounterClass
    {
        public static void CountLetters()
        {
            string fileString = ReadFileToString();
            if (fileString == string.Empty)
                return;

            int lettersCount = fileString.Count(char.IsLetter);
            Console.WriteLine("There are {0} letters in the file\n", lettersCount);
        }

        //locate your static methods here to make app looks cleaner ;)
        //TODO

        public static void CountOfEveryLetter()
        {
            string fileString = ReadFileToString();
            if (fileString == string.Empty)
                return;


            var charLookup = fileString.ToUpper().Where(char.IsLetter).ToLookup(letter => letter);
            foreach (var letter in charLookup)
                Console.WriteLine("{0}: {1}", letter.Key, charLookup[letter.Key].Count());
            Console.WriteLine();
        }

        public static void DownloadFileFromWeb()
        {
            Console.WriteLine("Download request processing!\n");
            string remoteUri = "https://s3.zylowski.net/public/input/2.txt";

            WebClient myWebClient = new WebClient();
            Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", "2.txt",
                remoteUri.Substring(0, remoteUri.Length - 5));

            myWebClient.DownloadFile(remoteUri, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//webText.txt");
            Console.WriteLine("Successfully Downloaded File \"{0}\"\n", remoteUri);
        }

        public static void CountWordsInText()
        {
            string fileString = ReadFileToString();
            if (fileString == string.Empty)
                return;

            string[] source = fileString.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var matchQuery = from word in source select word;
            int wordCount = matchQuery.Count();
            Console.WriteLine("The number of words in the file is {0}\n", wordCount);

        }

        public static string ReadFileToString()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//webText.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("ERROR! You must first download the file!!!\n");
                return string.Empty;
            }           
            string fileString = File.ReadAllText(path);
            return fileString;
        }
    }
}
