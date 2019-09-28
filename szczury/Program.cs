using System;
using System.Linq;

namespace szczury
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            while (isWorking)
            {
                Console.WriteLine("Input number");
                Console.WriteLine("6 - letters counting test");
                short number = 99;
                try
                {
                    number = Convert.ToInt16(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                switch (number)
                {
                    case 6:
                        lettersCounting();
                        break;
                    case 0:
                        Console.WriteLine("Closing");
                        isWorking = false;
                        break;
                    case 1:
                        break;
                }
            }
        }

        static void lettersCounting()
        {
            string test = "abbcc daba grabaz!! 123? A!";
            Console.WriteLine("Counting ... \n{0}",test);
            int abc = test.Count(char.IsLetter);
            Console.WriteLine(abc);

            CharCounter CC = new CharCounter(test);
            //GC.Collect();
        }
    }
}
