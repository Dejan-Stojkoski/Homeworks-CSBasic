using System;

namespace RealCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the First number:");
            string firstNumberString= Console.ReadLine();

            Console.WriteLine("Enter the Second number:");
            string secondNumberString = Console.ReadLine();

            Console.WriteLine("Enter the Operation:");
            string operation = Console.ReadLine();

            bool successfulConversion1 = double.TryParse(firstNumberString, out double firstNumber);
            bool successfulConversion2 = double.TryParse(secondNumberString, out double secondNumber);

            if(successfulConversion1 && successfulConversion2)
            {
                switch (operation)
                {
                    case "+":
                        Console.WriteLine("The result is " + (firstNumber + secondNumber));
                        break;

                    case "-":
                        Console.WriteLine("The result is " + (firstNumber - secondNumber));
                        break;

                    case "/":
                        Console.WriteLine("The result is " + (firstNumber / secondNumber));
                        break;

                    case "*":
                        Console.WriteLine("The result is " + (firstNumber * secondNumber));
                        break;

                    default :
                        Console.WriteLine("Invalid Operator!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid numbers input!");
            }
        }
    }
}
