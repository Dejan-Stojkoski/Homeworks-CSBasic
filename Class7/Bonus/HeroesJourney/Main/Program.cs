using System;
using Models;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] users = new User[]
            {
                new User("greg_gregsky@hotmail.com", "greg123"),
                new User("bob.bobsky@gmail.com", "bob123"),
                new User("dejan@dejan.com", "dejan")
            };

            while (true)
            {
                Console.WriteLine("Welcome to Heroes Jorney! Write:\n1.Register \n2.Login");
                string choiceInput = Console.ReadLine();

                bool validChoice = int.TryParse(choiceInput, out int choice);

                if (validChoice && (choice == 1 || choice == 2))
                {
                    switch (choice)
                    {
                        case 1:
                            users = Register(users);
                            Console.WriteLine("\nYou have successfully registered! Please Login: ");
                            Login(users);
                            break;

                        case 2:
                            Login(users);
                            break;
                    }
                }
                else
                {
                    Console.Write("Invalid choice. Try again. ");
                    continue;
                }

                break;
            }
        }




        static string ValidateEmail(string email)
        {
            int at = email.IndexOf('@');

            if (at != -1 && at > 2)
            {
                string[] restOfTheEmail = email.Split('@');
                int dot = restOfTheEmail[1].IndexOf('.');

                if(dot != -1 && dot > 2)
                {
                    string[] com = restOfTheEmail[1].Split('.');
                    if(com.Length == 2 && com[1].Length == 3)
                    {
                        return email;
                    }
                }
            }

            return "0";
        }



        static string EnterEmail()
        {
            Console.Write("Please enter email address: ");
            string emailInput = Console.ReadLine();

            string email = ValidateEmail(emailInput);

            return email;
        }



        static string EnterPassword()
        {
            Console.Write("Please enter password: ");
            string password = Console.ReadLine();

            return password;
        }



        static void Login(User[] users)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == 4)
                {
                    Console.WriteLine("\n\nLAST ATTEMPT. If the input is invalid you will be shown the home screen!");
                }

                string email = EnterEmail();
                string password = EnterPassword();
                bool flag = false;

                if (email != "0" && password.Length != 0)
                {
                    foreach (User user in users)
                    {
                        if (user.Email == email && user.GetPassword() == password)
                        {
                            Console.WriteLine($"\nWelcome {user.Email}\n");

                            user.SetCharacter(ChooseCharacter());
                            Console.WriteLine(user.Character.GetCharacterInfo());
                            Console.WriteLine($"\n{Play(user)}");

                            int choice;
                            do
                            {
                                Console.WriteLine("Do you want to play again? \n1. Yes \n2. No");
                                string choiceString = Console.ReadLine();

                                bool validChoice = int.TryParse(choiceString, out choice);
                                if (validChoice && (choice == 1 || choice == 2))
                                {
                                    switch (choice)
                                    {
                                        case 1:
                                            Console.WriteLine($"\n{Play(user)}");
                                            break;
                                        case 2:
                                            Console.WriteLine("\nSee you next time!");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.Write("Wrong input! ");
                                    continue;
                                }
                            }
                            while (choice == 1);
                            

                            flag = true;
                            break;
                        }
                    }
                }

                if (flag) return;

                if (i < 3)
                {
                    Console.WriteLine("\nInvalid email or password. Please try again.");
                }
            }
        }



        static User[] Register(User[] users)
        {
            while (true)
            {
                bool flag = false;
                string email = EnterEmail();

                if (email == "0")
                {
                    Console.Write("Invalid email! Try again. ");
                    continue;
                }

                foreach(User user in users)
                {
                    if(email == user.Email)
                    {
                        Console.WriteLine("This email is already in use!");
                        flag = true;
                        break;
                    }
                }

                if (flag == true) continue;

                string password = EnterPassword();

                if (password.Length != 0)
                {
                    Array.Resize(ref users, users.Length + 1);
                    users[^1] = new User(email, password);
                    return users;
                }

                Console.Write("Invalid password! Try again. ");
            }
        }


        static Character ChooseCharacter()
        {
            while (true)
            {
                Console.Write("Please enter you character name: ");
                 string name = Console.ReadLine();

                 if (name.Length == 1 || name.Length > 20)
                 {
                     Console.WriteLine("The name must have more than 1 letter and shorter than 20.\n");
                     continue;
                 }

                while (true)
                {
                    Console.WriteLine("\nPlease choose your character race: \n1. Dwarf \n2. Elf \n3. Human");
                    string characterInput = Console.ReadLine();

                    bool validCharacter = int.TryParse(characterInput, out int character);

                    if (validCharacter && character <= 3 && character >= 1)
                    {
                        switch (character)
                        {
                            case 1:
                                return new Character(name, Race.Dwarf, ChooseClass());
                            case 2:
                                 return new Character(name, Race.Elf, ChooseClass());
                            case 3:
                                return new Character(name, Race.Human, ChooseClass());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong input. Please try again. ");
                        continue;
                    }
                }
            }
        }



        static Class ChooseClass()
        {
            while (true)
            {
                Console.WriteLine("\nPlease choose the class of your character: \n1. Warrior \n2. Rogue \n3. Mage");
                string classInput = Console.ReadLine();

                bool validClass = int.TryParse(classInput, out int chosenClass);

                if (validClass && chosenClass <= 3 && chosenClass >= 1)
                {
                    switch (chosenClass)
                    {
                        case 1:
                            return Class.Warrior;
                        case 2:
                            return Class.Rogue;
                        case 3:
                            return Class.Mage;
                    }
                }
                else Console.WriteLine("Invalid input. Try again. ");
            }
        }



        static string Play(User user)
        {
            Event[] events = new Event[]
            {
                new Event("Bandits attack you out of nowhere. They seem very dangerous...", -20),
                new Event("You bump in to one of the guards of the nearby village. They attack you without warning...", -30),
                new Event("A Land Shark appears. It starts chasing you down to eat you...", -50),
                new Event("You accidentally step on a rat. His friends are not happy. They attack...", -10),
                new Event("You find a huge rock. It comes alive somehow and tries to smash you...", -30)
            };

            Random num = new Random();

            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"\n{events[i].Description}");

                while (true)
                {
                    Console.WriteLine("What do you want to do? \n1. Fight \n2. Run Away");
                    string choiceString = Console.ReadLine();
                    bool validChoice = int.TryParse(choiceString, out int choice);

                    if (validChoice && (choice == 1 || choice == 2))
                    {
                        switch (choice)
                        {
                            case 1:
                                if (num.Next(1, 11) < user.Character.Strength)
                                {
                                    Console.WriteLine("You won fight!");
                                }
                                else
                                {
                                    Console.WriteLine("You lost fight!");
                                    user.Character.SetHealth(events[i].Health);
                                    if (user.Character.Health <= 0) return "YOU LOST!";
                                    else Console.WriteLine($"You have {user.Character.Health} HP left.");
                                }
                                break;

                            case 2:
                                if (num.Next(1, 11) < user.Character.Agility)
                                {
                                    Console.WriteLine("You have run away!");
                                }
                                else
                                {
                                    Console.WriteLine("You were unable to run away!");
                                    user.Character.SetHealth(events[i].Health);
                                    if (user.Character.Health <= 0) return "YOU LOST!";
                                    else Console.WriteLine($"You have {user.Character.Health} HP left.");
                                }
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong Input! Try again.");
                        continue;
                    }
                    break;
                }
            }

            return "YOU WON!";
        }
    }
}
