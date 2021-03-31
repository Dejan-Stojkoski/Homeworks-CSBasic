using System;

namespace SecondSmallestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[0];

            while (true)
            {
                Console.Write("How many numbers do you want to enter? ");
                string arrayLengthString = Console.ReadLine();
                bool lengthParse = int.TryParse(arrayLengthString, out int arrayLength);

                if (lengthParse)
                {
                    Array.Resize(ref numbers, arrayLength);

                    for(int i=0; i<arrayLength; i++)
                    {
                        Console.Write("Enter an integer number: ");
                        string numberString = Console.ReadLine();
                        bool success = int.TryParse(numberString, out int number);

                        if (success)
                        {
                            numbers[i] = number;
                        }
                        else
                        {
                            Console.Write("Wrong input. Try again. ");
                            i--;
                        }
                    }

                    break;
                }
                else
                {
                    Console.Write("Wrong input! Try again. ");
                }
            }

            int[] sortedNumbers = new int[numbers.Length];
            numbers.CopyTo(sortedNumbers, 0);

            for (int i = 0; i < sortedNumbers.Length; i++)
            {
                for (int j = i + 1; j < sortedNumbers.Length; j++)
                {
                    if (sortedNumbers[i] > sortedNumbers[j])
                    {
                        int temp = sortedNumbers[i];
                        sortedNumbers[i] = sortedNumbers[j];
                        sortedNumbers[j] = temp;
                    }
                }
            }

            Console.Write("\n\nNumbers: ");
            for (int i=0; i<numbers.Length; i++)
            {
                Console.Write(numbers[i]);
                if (i < numbers.Length - 1) Console.Write(", ");
                else Console.WriteLine(".");
            }

            if (sortedNumbers.Length > 1) Console.WriteLine("The second smallest number is: " + sortedNumbers[1]);
            else Console.WriteLine("You only have one number, and it is: " + sortedNumbers[0]);
        }
    }
}
