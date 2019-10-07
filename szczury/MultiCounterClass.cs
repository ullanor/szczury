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
        static string textIndendation = "\n\n";
        public static void DownloadFileFromWeb()
        {
            Console.WriteLine("Download request processing!\n");
            string remoteUri = "https://s3.zylowski.net/public/input/2.txt";

            WebClient myWebClient = new WebClient();
            Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n", "2.txt",
                remoteUri.Substring(0, remoteUri.Length - 5));

            myWebClient.DownloadFile(remoteUri, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//webText.txt");
            Console.WriteLine("Successfully Downloaded File \"{0}\"\n", remoteUri);
        }

        //locate your static methods here to make app looks cleaner ;)
        //TODO

        public static string CountWordsInText()
        {
            string fileString = ReadFileToString();
            if (fileString == string.Empty)
                return fileString;

            string[] source = fileString.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var matchQuery = from word in source select word;
            int wordCount = matchQuery.Count();
            return "The number of words in the file is " + wordCount + textIndendation;

        }

        public static string CountLetters()
        {
            string fileString = ReadFileToString();
            if (fileString == string.Empty)
                return fileString;

            int lettersCount = fileString.Count(char.IsLetter);
            return "There are " + lettersCount + " letters in the file" + textIndendation;
        }

        public static string CountPunctuationMarks()
        {
            string tester = ReadFileToString();
            char[] punctuationMarks = { '!', '?', '.', ':', ';', ',', '-', '[', ']', '{', '}', '(', ')', '\'', '\"' };
            int result = tester.ToCharArray().Count(c => (punctuationMarks.Contains(c)));
            return "Number of punctuation marks: " + result;
        }

        public static string CountSentences()
        {
            string tester = ReadFileToString();
            string pattern = "(?<!(\\?|\\.|!))(\\?|\\.|!)";
            int doubled = System.Text.RegularExpressions.Regex.Matches(tester, pattern).Count;
            return "Number of sentences: " + doubled;
        }

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

        public static void SaveStatistics()
        {
            string docPath =
                  Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "statystyki.txt")))
            {
                outputFile.WriteLine(CountSentences());
                outputFile.WriteLine(CountPunctuationMarks());
            }
            Console.WriteLine("statystyki.txt was created successfully!");
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
