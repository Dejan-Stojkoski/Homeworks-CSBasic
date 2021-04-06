using System;
using ATM.Classes;


namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            Users[] users = new Users[]
            {
                new Users ("Bob Bobsky", 2121313141415151),
                new Users ("Greg Gregsky", 1234567891234567)
            };

            users[0].setPin(1234);
            users[0].setBalance(500.65);
            users[1].setPin(4321);
            users[1].setBalance(1000.59);

            Console.WriteLine("Welcome to the ATM application.\n");

            while (true)
            {
                Console.WriteLine("Are you a registered ATM user? (Yes/No) ");
                string registerCheck = Console.ReadLine();

                if (registerCheck.ToLower() != "yes" && registerCheck.ToLower() != "no")
                {
                    Console.Write("Wrong input! Try again. ");
                    continue;
                }
                else if (registerCheck.ToLower() == "no")
                {
                    Console.WriteLine("\nThank you for choosing our services!");
                    Console.Write("\nPlease enter your card number: ");
                    string registerCardNumberString = Console.ReadLine();
                    long registerCardNumber = ValidateCardNumber(registerCardNumberString);

                    if (registerCardNumber == 0)
                    {
                        Console.Write("Wrong input! Try again. ");
                        continue;
                    }

                    if (CheckIfTheUserExist(users, registerCardNumber))
                    {
                        Console.Write("The card number is already in use! ");
                        continue;
                    }

                    Console.Write("Please enter your full name: ");
                    string registerName = Console.ReadLine();

                    Array.Resize(ref users, users.Length + 1);
                    users[users.Length - 1] = new Users(registerName, registerCardNumber);

                    while (true)
                    {
                        Console.Write("Please enter your PIN number - 4 digits: ");
                        string pinString = Console.ReadLine();

                        int registerPin = ValidatePinNumber(pinString);
                        if (registerPin > 0)
                        {
                            users[users.Length - 1].setPin(registerPin);
                            break;
                        }
                        else Console.Write("Your pin number is invalid. Try again. ");
                    }

                    Console.WriteLine("\n\n\nThank you for your registration! Please use your card number and pin to log into your account!");
                }

                Users currentUser;

                Console.Write("Please enter your card number: ");
                string cardNumberInput = Console.ReadLine();
                long cardNumber = ValidateCardNumber(cardNumberInput);
                if (cardNumber == 0)
                {
                    Console.Write("Invalid card number! Try again. ");
                    continue;
                }

                Console.Write("Please enter your pin: ");
                string pinInputString = Console.ReadLine();

                bool pinParseSuccess = int.TryParse(pinInputString, out int pinInput);

                if (pinParseSuccess && (pinInput > 999 && pinInput < 10000))
                {
                    currentUser = CheckForUser(users, cardNumber, pinInput);
                    if (currentUser == null)
                    {
                        Console.WriteLine("User not found! Try again!\n");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid pin number. Try again!\n");
                    continue;
                }

                Console.WriteLine($"\nWelcome {currentUser.Name}!");

                while (true)
                {
                    Console.WriteLine($"\nWhat would you like to do:\n");
                    foreach (string option in currentUser.Options)
                    {
                        Console.WriteLine(option);
                    }

                    string chosenOptionString = Console.ReadLine();
                    bool optionParseSuccess = int.TryParse(chosenOptionString, out int chosenOption);

                    if (optionParseSuccess && (chosenOption > 0 && chosenOption < 4))
                    {
                        SelectOption(currentUser, chosenOption);
                    }
                    else Console.Write("There is no such option. Try again. ");

                    Console.WriteLine(@"If you want another transaction please enter ""yes"": ");
                    string anotherTransaction = Console.ReadLine();

                    if (anotherTransaction.ToLower() == "yes") continue;
                    else Console.WriteLine($"\nThank you for using the ATM app.");
                    break;
                }

                break;
            }
        }


        static long ValidateCardNumber(string cardNumberInput)
        {
            string cardNumberString = "";
            long temp = 0;

            if (cardNumberInput.Length < 19 || (cardNumberInput[4] != '-' && cardNumberInput[8] != '-' && cardNumberInput[12] != '-'))
            {
                return temp;
            }
            else
            {
                string[] cardSplit = cardNumberInput.Split('-');
                foreach (string part in cardSplit)
                {
                    cardNumberString += part;
                }

                bool success = long.TryParse(cardNumberString, out long cardNumber);

                if (success) return cardNumber;
                else return temp;
            }
        }
        static Users CheckForUser(Users[] users, long cardNumber, int pin = 00000)
        {
            Users currentUser = null; ;

            foreach (Users user in users)
            {
                if (user.CardNumber == cardNumber && user.getPin() == pin)
                {
                    currentUser = user;
                    break;
                }
            }

            return currentUser;
        }

        static void SelectOption(Users user, int option)
        {
            Console.WriteLine("");
            switch (option)
            {
                case 1:
                    Console.WriteLine(user.BalanceChecking());
                    break;

                case 2:
                    Console.WriteLine("Cash Withdrawl\n");
                    ExecuteOption(user.CashWithdrawl);
                    break;

                case 3:
                    Console.WriteLine("Cash Deposit\n");
                    ExecuteOption(user.CashDeposition);
                    break;
            }
        }
        static void ExecuteOption(Func<double, string> userMethod)
        {
            while (true)
            {
                Console.Write("Enter amount: $");
                string cashString = Console.ReadLine();

                bool validParse = double.TryParse(cashString, out double cash);
                if (validParse && cash > 0)
                {
                    Console.WriteLine(userMethod.Invoke(cash));
                    break;
                }
                else
                {
                    Console.Write("Invalid amount. Please try again. ");
                    continue;
                }
            }
        }
        static bool CheckIfTheUserExist(Users[] users, long cardNumber)
        {
            bool found = false;
            foreach (Users user in users)
            {
                if (user.CardNumber == cardNumber)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
        static int  ValidatePinNumber(string pinString)
        {
            bool success = int.TryParse(pinString, out int pin);

            if (success && pin > 999 && pin < 10000) return pin;
            else return 0;
        }
    }
}
