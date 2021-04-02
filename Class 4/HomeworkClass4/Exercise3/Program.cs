using System;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        { 
            while (true)
            {
                Console.Write("If you want to enter your own string write Y, else write anything:  ");
                string check = Console.ReadLine();
                string ownString = "";

                if(check == "y" || check == "Y")
                {
                    Console.Write("Enter your string: ");
                    ownString = Console.ReadLine();
                    if(ownString.Length == 0)
                    {
                        Console.WriteLine("You have not entered a string! Try again.");
                        continue;
                    }
                }

                Console.Write("How many characters of the given string you want to see? ");
                string numberString = Console.ReadLine();

                bool parseSuccess = int.TryParse(numberString, out int number);

                if (parseSuccess && number > 0)
                {
                    if(ownString.Length > 0)
                    {
                        Substring(number, ownString);
                        break;
                    }
                    else
                    {
                        Substring(number);
                        break;
                    }
                }
                else Console.WriteLine("Wrong input! You can only see positive integer number of characters! Please try again!");
            }

        }

        static void Substring(int number, string mainString = "Hello from SEDC Codecademy 2021")
        {
            if (number > mainString.Length) Console.WriteLine($"\n There are only {mainString.Length} characters in the string!");
            else
            {
                string resultString = mainString.Substring(0, number);
                Console.WriteLine($@"The characters you wanted to see are: ""{resultString}"", and there are {resultString.Length} characters in the new string.");
            }

        }
    }
}
