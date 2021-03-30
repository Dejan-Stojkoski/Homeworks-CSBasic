using System;

namespace SumOfEven
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[6];
            int sum = 0;

            for(int i=0; i<6; i++)
            {
                Console.Write("Enter integer no." + (i + 1) + ": ");
                string numberString = Console.ReadLine();

                bool success = int.TryParse(numberString, out int number);

                if (success)
                {
                    numbers[i] = number;
                    if (number % 2 == 0) sum+=number;
                }
                else
                {
                    Console.WriteLine("Wrong input. Please try again!");
                    i--;
                }
            }

            Console.WriteLine("\n\nThe result is: " + sum);
        }
    }
}
