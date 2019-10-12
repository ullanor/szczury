using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace szczury
{
    static class MultiCounterClass
    {
        static string textIndendation = "\n\n";
        public static void DownloadFileFromWeb()
        {
            string address = string.Empty;
            string choosed = string.Empty;
            Console.WriteLine("Do you want to download file from web?[Y/N]");
            choosed = Console.ReadLine();

            if (choosed.Length > 1) return;
            if (char.ToUpper(Convert.ToChar(choosed)) == 'Y')
            {
                Console.Write("Input file address: ");
                address = Console.ReadLine();
            }
            else
            {
                Console.Write("Input file name: ");
                address += Environment.CurrentDirectory + "/";
                address += Console.ReadLine();

                try
                {
                    Console.WriteLine(File.ReadAllText(address));
                }catch(Exception ext) { Console.WriteLine("ERROR no file!"); }
                return;
            }

            //Console.WriteLine("Download request processing!\n");
            //string remoteUri = "https://s3.zylowski.net/public/input/2.txt";

            WebClient myWebClient = new WebClient();
            //Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n", "2.txt",
            //remoteUri.Substring(0, remoteUri.Length - 5));
            try
            {
                myWebClient.DownloadFile(address, Environment.CurrentDirectory + "//webText.txt");
            }
            catch (Exception ex) 
            { 
                Console.WriteLine("File NOT found!");
                return;
            }
            Console.WriteLine("Successfully Downloaded File \"{0}\"\n", address);
        }

        //locate your static methods here to make app looks cleaner ;)
        //TODO

        public static string CountWordsInText()
        {
            string fileString = ReadFileToString();
            if (fileString == string.Empty)
                return fileString;

            string[] source = fileString.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int counter = 0;
            foreach (string word in source)
            {
                if (word.Length > 1)
                    counter++;
                //var matchQuery = from word in source select word;
                //int wordCount = matchQuery.Count();
            }
            return "The number of words in the file is " + counter + textIndendation;

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


        public static string CountLetters()
        {
            string fileString = ReadFileToString();
            if (fileString == string.Empty)
                return fileString;

            int lettersCount = fileString.Count(char.IsLetter);
            char[] vowels = { 'A', 'E', 'I', 'O', 'U', 'Y' };
            //if (vowel.Contains(fileString.Count(char.IsLetter)))
            char[] charsFromTekst = fileString.ToArray();

            int counter = 0;
            foreach(char charek in charsFromTekst)
            {
                if (vowels.Contains(char.ToUpper(charek)))
                {
                    counter++;
                }
            }

            
            int cons = lettersCount - counter;
            string vowels2 = "Vowels: " + counter + " Cons: "+ cons;

            return "There are " + lettersCount + " letters in the file \n" + vowels2+ textIndendation;
        }

        public static string CountPunctuationMarks()
        {
            string tester = ReadFileToString();
            if (tester == string.Empty)
                return tester;
            char[] punctuationMarks = { '!', '?', '.', ':', ';', ',', '-', '[', ']', '{', '}', '(', ')', '\'', '\"' };
            int result = tester.ToCharArray().Count(c => (punctuationMarks.Contains(c)));
            return "Number of punctuation marks: " + result + textIndendation;

        }

        public static string CountSentences()
        {
            string tester = ReadFileToString();
            if (tester == string.Empty)
                return tester;

            string pattern = "(\\?|\\.)";
            int doubled = Regex.Matches(tester, pattern).Count;
            return "Number of sentences: " + doubled + textIndendation;
        }

        public static void SaveStatFile()
        {
            string SuperTester = ReadFileToString();
            if (SuperTester == string.Empty)
                return;

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "statystyki.txt")))
            {
                outputFile.WriteLine(CountLetters());
                outputFile.WriteLine(CountWordsInText());
                outputFile.WriteLine(CountPunctuationMarks());
                outputFile.WriteLine(CountSentences());
            }           
            Console.WriteLine("statystyki.txt was created successfully!\n");
        }

        public static string ReadFileToString()
        {
            string path = Environment.CurrentDirectory + "//webText.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("ERROR! You must first download the file!!!\n");
                return string.Empty;
            }           
            string fileString = File.ReadAllText(path);
            return fileString;
        }

        public static void RemoveDownloadedFile()
        {
            string path = Environment.CurrentDirectory + "//webText.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine("webText.txt was deleted!\n");

        }
            string path2 = Environment.CurrentDirectory + "//statystyki.txt";
            if (File.Exists(path2))
            {
                File.Delete(path2);
                Console.WriteLine("statystyki.txt was deleted!\n");
            }

        }
    }
}
