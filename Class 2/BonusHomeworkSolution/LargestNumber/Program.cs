using System;

namespace LargestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the First number: ");
            string firstNumberString = Console.ReadLine();

            Console.Write("Enter the Second number: ");
            string secondNumberString = Console.ReadLine();

            Console.Write("Enter the Third number: ");
            string thirdNumberString = Console.ReadLine();

            Console.Write("Enter the Fourth number: ");
            string fourthNumberString = Console.ReadLine();

            bool successfulConversion1 = float.TryParse(firstNumberString, out float firstNumber);
            bool successfulConversion2 = float.TryParse(secondNumberString, out float secondNumber);
            bool successfulConversion3 = float.TryParse(thirdNumberString, out float thirdNumber);
            bool successfulConversion4 = float.TryParse(fourthNumberString, out float fourthNumber);

            if(successfulConversion1 && successfulConversion2 && successfulConversion3 && successfulConversion4)
            {
                float biggestNumber = firstNumber;
                if (secondNumber > biggestNumber) biggestNumber = secondNumber;
                if (thirdNumber > biggestNumber) biggestNumber = thirdNumber;
                if (fourthNumber > biggestNumber) biggestNumber = fourthNumber;

                Console.WriteLine("\n\nThe largest of " + firstNumber + ", " + secondNumber + ", " + thirdNumber + " and " + fourthNumber + " is: " + biggestNumber);
            }
            else
            {
                Console.WriteLine("Wrong input numbers!");
            }
        }
    }
}
