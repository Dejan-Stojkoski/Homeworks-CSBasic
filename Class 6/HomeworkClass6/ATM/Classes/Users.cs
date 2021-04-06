using System.Globalization;
namespace ATM.Classes
{
    public class Users
    {
        public string Name { get; set; }
        public long CardNumber { get; set; }
        private int Pin { get; set; }
        private double Balance { get; set; } = 0;
        public string[] Options { get; set; } = new string[] { "1. Check Balance", "2. Cash Withdrawl", "3. Cash Deposit" };

        public Users() {}
        public Users(string name, long cardNumber)
        {
            Name = name;
            CardNumber = cardNumber;
        }


        public void setPin(int pin)
        {
            Pin = pin;
        }
        public void setBalance(double balance)
        {
            Balance = balance;
        }
        public int getPin()
        {
            return Pin;
        }
        public double getBalance()
        {
            return Balance;
        }


        public string BalanceChecking()
        {
            return $"Your curent balance is {Balance.ToString("C", new CultureInfo("en-US"))}.";
        }

        public string CashWithdrawl(double cash)
        {
            if (Balance > cash)
            {
                if (cash < 10) return $"You can't withdraw less than $10.";
                Balance -= cash;
                return $"Transaction successfyl! You have withdrawn {cash.ToString("C", new CultureInfo("en-US"))} and your current balance is {Balance.ToString("C", new CultureInfo("en-US"))}.";
            }
            else return $"You don't have enough money for the following transaction!";
        }

        public string CashDeposition(double cash)
        {
            if (cash > 10)
            {
                Balance += cash;
                return $"You have successfully deposit {cash.ToString("C", new CultureInfo("en-US"))}. Your current balance is {Balance.ToString("C", new CultureInfo("en-US"))}";
            }
            else return "You can not deposit less than $10.";
        }
    }
}
