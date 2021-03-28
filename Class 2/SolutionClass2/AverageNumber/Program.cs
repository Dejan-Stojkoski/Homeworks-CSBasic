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

            bool successfulConversion1 = float.TryParse(firstNumberString, out float firstNumber);
            bool successfulConversion2 = float.TryParse(secondNumberString, out float secondNumber);
            bool successfulConversion3 = float.TryParse(thirdNumberString, out float thirdNumber);
            bool successfulConversion4 = float.TryParse(fourthNumberString, out float fourthNumber);

            if(successfulConversion1 && successfulConversion2 && successfulConversion3 && successfulConversion4)
            {
                float result = (firstNumber + secondNumber + thirdNumber + fourthNumber) / 4;
                Console.WriteLine("The average of " + firstNumber + ", " + secondNumber + ", " + thirdNumber + " and " + fourthNumber + " is: " + result);
            }
            else
            {
                Console.WriteLine("Invalid number input!");
            }
        }
    }
}
