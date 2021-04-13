using System;
using System.Collections;
using System.Collections.Generic;

namespace CreateCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> numberQueue = new Queue<int>();

            Stack<int> numberStack = new Stack<int>();

            List<int> numberList = new List<int>();

            string check = "";

            do
            {
                Console.Write("Please enter a number: ");
                string numberString = Console.ReadLine();

                if (int.TryParse(numberString, out int number))
                {
                    numberQueue.Enqueue(number);
                    numberStack.Push(number);
                    numberList.Add(number);
                }
                else
                {
                    Console.Write("The input must be integer number! Please try again. ");
                    continue;
                }

                Console.Write(@"If you want to enter another number please enter ""Y"", if you want to exit enter anything: ");
                check = Console.ReadLine();
            }
            while (check.ToLower() == "y");

            Console.Write($"\n\nThe items from QUEUE are: ");
            PrintCollection(numberQueue);

            Console.Write($"\n\nThe items from STACK are: ");
            PrintCollection(numberStack);

            Console.Write($"\n\nThe items from LIST are: ");
            PrintCollection(numberList);

        }


        static void PrintCollection(IEnumerable collection)
        {
            foreach(object item in collection)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
