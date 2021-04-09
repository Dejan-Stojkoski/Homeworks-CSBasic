using System;
namespace Models
{
    public class CEO : Employee
    {
        public Employee[] Employees { get; set; }
        private int Shares { get; set; } = 0;
        public double SharesPrice { get; private set; }

        public void SetShares(int shares)
        {
            Shares = shares;
        }

        public CEO(string firstname, string lastname, double salary, Employee[] employees) : base(firstname, lastname, Role.CEO, salary)
        {
            Employees = employees;
        }

        public void AddSharesPrice(double sharesPrice)
        {
            SharesPrice = sharesPrice;
        }

        public string[] GetEmployees()
        {
            string[] employeeNames = new string[Employees.Length];

            for(int i=0; i<Employees.Length; i++)
            {
                employeeNames[i] =  Employees[i].FullName;
            }

            return employeeNames;
        }

        public override double GetSalary()
        {
            return Salary + (Shares * SharesPrice);
        }
    }
}
