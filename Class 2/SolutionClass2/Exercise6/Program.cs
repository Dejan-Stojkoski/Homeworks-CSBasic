using System;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first integer number:");
            string firstNumberString = Console.ReadLine();

            Console.WriteLine("Enter the second integer number:");
            string secondNumberString = Console.ReadLine();

            bool successfulConversion1 = int.TryParse(firstNumberString, out int firstNumber);
            bool successfulConversion2 = int.TryParse(secondNumberString, out int secondNumber);

            if(successfulConversion1 && successfulConversion2)
            {
                int theBiggerNumber = firstNumber > secondNumber ?  firstNumber :  secondNumber;

                Console.WriteLine("The bigger number is " + theBiggerNumber);
                if (theBiggerNumber % 2 == 0)
                {
                    Console.WriteLine("This number is even.");
                }
                else
                {
                    Console.WriteLine("This number is odd.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
