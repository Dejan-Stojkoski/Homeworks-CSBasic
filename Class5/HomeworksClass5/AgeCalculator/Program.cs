using System;

namespace AgeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter your birthday: ");
                string birthdayString = Console.ReadLine();

                bool validParse = DateTime.TryParse(birthdayString, out DateTime birthday);

                if (validParse && birthday < DateTime.Now)
                {
                    Console.WriteLine(AgeCalculator(birthday));
                    break;
                }
                else Console.Write("Invalid date! Try again! ");
            }
        }

        static string AgeCalculator(DateTime birthday)
        {
            DateTime now = DateTime.Today;
            string isYourBirthday = "";

            int age = now.Year - birthday.Year;
            if (birthday.Month > now.Month)
            {
                age--;
            }
            

            if(birthday.Month == now.Month)
            {
                if (birthday.Day == now.Day) isYourBirthday = "Today is your birthday! Happy birthday!";

                DateTime oneDayBefore = now.AddDays(-1);
                if (oneDayBefore.Day == birthday.Day) isYourBirthday = "Yesterday was your birthday! Happy late birthday!";

                DateTime oneDayAfter = now.AddDays(1);
                if (oneDayAfter.Day == birthday.Day) isYourBirthday = "Tomorrow is your bithday! Happy early birthday!";
            }
            return $"You are {age} old. {isYourBirthday}";
        }
    }
}
