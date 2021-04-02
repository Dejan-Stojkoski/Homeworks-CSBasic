using System;

namespace FunWithStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a sentence: ");
            string mainString = Console.ReadLine();

            FunWithStrings(mainString);
        }

        static void FunWithStrings(string mainString)
        {
            char[] charString = mainString.ToCharArray();
            Array.Reverse(charString);
            string reversedString = new string(charString);

            mainString.ToLower();
            int countVowels = 0;
            foreach(char item in charString)
            {
                if(item == 'a' || item == 'o' || item == 'i' || item == 'u' || item == 'e')
                {
                    countVowels++;
                }
            }

            string[] splitedString = mainString.Split(" ");
            string largestWord = splitedString[0];
            string smallestWord = splitedString[0];
            int wordsCount = 0;
            foreach (string word in splitedString)
            {
                if (word.Length > largestWord.Length) largestWord = word;
                if (word.Length < smallestWord.Length) smallestWord = word;
                if (word.Length > 0 && word != " ") wordsCount++;
            }



            Console.WriteLine($"\nThis is the reversed string: {reversedString}");
            Console.WriteLine($"There were {countVowels} vowels found!");
            Console.WriteLine($"Is the string palindrome? {mainString == reversedString}");
            Console.WriteLine($@"The largest word is: ""{largestWord}""");
            Console.WriteLine($@"The smallest word is: ""{smallestWord}""");
            Console.WriteLine($@"The string have {wordsCount} words!");
            FindTheChar(mainString);

        }

        static void FindTheChar(string mainString)
        {
            int[] charCount = new int[256];
            int length = mainString.Length;
            for (int i = 0; i < length; i++)
            {
                charCount[mainString[i]]++;
            }
            int maxCount = -1;
            char character = ' ';
            for (int i = 0; i < length; i++)
            {
                if (maxCount < charCount[mainString[i]])
                {
                    maxCount = charCount[mainString[i]];
                    character = mainString[i];
                }
            }
            Console.WriteLine($@"The most used character is ""{character}"" and it appears {maxCount} times.");
        }
    }
}
