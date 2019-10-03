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
            {
                Console.WriteLine("\nYou must first load the file!!!\n");
                return;
            }

            string[] source = fileString.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var matchQuery = from word in source select word;
            int wordCount = matchQuery.Count();
            Console.WriteLine("\nThe number of words in the file is {0}\n", wordCount);




        }

        public static string ReadFileToString()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//webText.txt";
            if (!File.Exists(path))
                return string.Empty;
            string fileString = File.ReadAllText(path);
            return fileString;
        }
    }
}
