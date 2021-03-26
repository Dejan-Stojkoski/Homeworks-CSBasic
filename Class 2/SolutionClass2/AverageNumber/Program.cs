using System;

namespace AverageNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number:");
            string firstNumberString = Console.ReadLine();

            Console.WriteLine("Enter the second number:");
            string secondNumberString = Console.ReadLine();

            Console.WriteLine("Enter the third number:");
            string thirdNumberString = Console.ReadLine();

            Console.WriteLine("Enter the fourth number:");
            string fourthNumberString = Console.ReadLine();

            bool successfulConversion1 = int.TryParse(firstNumberString, out int firstNumber);
            bool successfulConversion2 = int.TryParse(secondNumberString, out int secondNumber);
            bool successfulConversion3 = int.TryParse(thirdNumberString, out int thirdNumber);
            bool successfulConversion4 = int.TryParse(fourthNumberString, out int fourthNumber);

            if(successfulConversion1 && successfulConversion2 && successfulConversion3 && successfulConversion4)
            {
                int result = (firstNumber + secondNumber + thirdNumber + fourthNumber) / 4;
                Console.WriteLine("The average of " + firstNumber + ", " + secondNumber + ", " + thirdNumber + " and " + fourthNumber + " is: " + result);
            }
            else
            {
                Console.WriteLine("Invalid number input!");
            }
        }
    }
}
