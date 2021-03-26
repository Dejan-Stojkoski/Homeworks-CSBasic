using System;

namespace SwapNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input the First Number:");
            string firstNumberString = Console.ReadLine();

            Console.WriteLine("Input the Second Number:");
            string secondNumberString = Console.ReadLine();

            bool successfulConversion1 = float.TryParse(firstNumberString, out float firstNumber);
            bool successfulConversion2 = float.TryParse(secondNumberString, out float secondNumber);

            if(successfulConversion1 && successfulConversion2)
            {
                float temp = firstNumber;
                firstNumber = secondNumber;
                secondNumber = temp;

                Console.WriteLine("\n\nAfter Swapping: \nFirst Number: " + firstNumber + "\nSecond Number: " + secondNumber);

            }
            else
            {
                Console.WriteLine("Invalid numbers!");
            }
        }
    }
}
