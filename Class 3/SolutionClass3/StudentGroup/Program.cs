using System;

namespace StudentGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] studentsG1 = new string[] { "Zdravko", "Petko", "Stanko", "Branko", "Trajko" };
            string[] studentsG2 = new string[] { "Bill", "Greg", "Tom", "Bob", "Fred" };

            while (true)
            {
                Console.Write("If you want to see the students from G1 write 1, for the students from G2 write 2! ");
                string groupString = Console.ReadLine();

                bool success = int.TryParse(groupString, out int group);

                if (success && (group == 1 || group == 2))
                {
                    switch (group)
                    {
                        case 1:
                            Console.WriteLine("The Students in G1 are:");
                            foreach (string student in studentsG1) Console.WriteLine(student);
                            break;

                        case 2:
                            Console.WriteLine("The Students in G2 are:");
                            foreach (string student in studentsG2) Console.WriteLine(student);
                            break;
                    }
                    break;
                }
                else
                {
                    Console.Write("Wrong input. Please try again. ");
                    continue;
                }
            }

        }
    }
}
