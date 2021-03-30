using System;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[0];

            while (true)
            {
                Console.Write("Please enter a name in the array : ");
                string name = Console.ReadLine();

                Array.Resize(ref names, names.Length + 1);
                names[names.Length - 1] = name;

                string check;
                while (true)
                {
                    Console.Write("If you want to enter another name write y, if not write n! ");
                    check = Console.ReadLine();

                    if(check != "y" && check != "Y" && check !="n" && check != "N") Console.Write("Wrong input!");
                    else break;
                }

                if (check == "y" || check == "Y") continue;
                else if (check == "n" || check == "N") break;
            }

            foreach(string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
