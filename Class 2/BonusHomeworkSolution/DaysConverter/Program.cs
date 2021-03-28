using System;

namespace DaysConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of days you want to convert: ");
            string daysString = Console.ReadLine();

            bool successfullConversionDays = int.TryParse(daysString, out int days);

            if (successfullConversionDays)
            {
                int years = days / 365;
                days -= (years * 365);
                int weeks = days / 7;
                days -= (weeks * 7);

                Console.WriteLine("\n\nYears: " + years + "\nWeeks: " + weeks + "\nDays: " + days);
                if (years == weeks && years == days)
                {
                    Console.WriteLine("You've entered a special number of days!");
                }
            }
            else
            {
                Console.WriteLine("Wrong input!");
            }
        }
    }
}
