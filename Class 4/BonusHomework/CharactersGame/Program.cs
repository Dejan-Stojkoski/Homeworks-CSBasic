using System;

namespace CharactersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter a full sentence: ");
                string sentence = Console.ReadLine();

                Console.Write("Enter a single character: ");
                string characterString = Console.ReadLine();

                bool validCharParse = char.TryParse(characterString, out char character);

                if(validCharParse && sentence.Length > 0)
                {
                    FindCharacter(sentence, character);

                    while (true)
                    {
                        Console.Write("\nEnter a number: ");
                        string numberString = Console.ReadLine();

                        bool validNumberParse = int.TryParse(numberString, out int number);

                        if (validNumberParse && number > 0)
                        {
                            Substring(sentence, number);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You can only enter positive integer numbers! Try again!");
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("You have not entered a sentence or your character input is invalid! Try again!");
                    continue;
                }
            }
        }

        static void FindCharacter(string sentence, char character)
        {
            string sentenceToLower = sentence.ToLower();
            char toLowerChar = char.ToLower(character);
            int count = 0;

            char[] charArray = sentenceToLower.ToCharArray();
            foreach(char item in charArray)
            {
                if(item == toLowerChar)
                {
                    count++;
                }
            }

            Console.WriteLine($@"The character ""{character}"" in the given sentence is found {count} times.");
        }

        static void Substring(string sentence, int number)
        {
            if (number > sentence.Length) Console.WriteLine($"There are only {sentence.Length} characters in the string!");
            else
            {
                string resultString = sentence.Substring(0, number);
                Console.WriteLine($@"The substring is: ""{resultString}""");
            }
        }
    }
}
