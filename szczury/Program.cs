using System;

namespace szczury
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            short number = 0;

            while (isWorking)
            {
                Console.WriteLine("1 - Download file from net");
                Console.WriteLine("2 - Count number of letters in file");
                Console.WriteLine("3 - Count number of words in file");
                Console.WriteLine("4 - Count number of punctuation marks in file");
                Console.WriteLine("5 - Count number of sentences in file");
                Console.WriteLine("6 - Generate report of used letters(A-Z)");
                Console.WriteLine("7 - Save statistics from options(2-5) as statystyki.txt");
                Console.WriteLine("8 - EXIT App");

                try
                {
                    number = Convert.ToInt16(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    Console.WriteLine();
                }

                switch (number)
                {
                    case 1:
                        MultiCounterClass.DownloadFileFromWeb();
                        break;
                    case 2:
                        MultiCounterClass.CountLetters();
                        break;
                    case 3:
                        MultiCounterClass.CountWordsInText();
                        break;

                    case 8:
                        Console.WriteLine("Closing App ...\n");
                        isWorking = false;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
