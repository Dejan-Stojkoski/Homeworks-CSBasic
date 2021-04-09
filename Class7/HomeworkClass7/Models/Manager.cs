namespace Models
{
    public class Manager : Employee
    {
        private double Bonus { get; set; }

        public Manager(string firstname, string lastname, double salary) : base(firstname, lastname, Role.Manager, salary)
        {

        }

        public void AddBonus(double bonus)
        {
            Bonus += bonus;
        }

        public override double GetSalary()
        {
            return Salary + Bonus;
        }
    }
}
