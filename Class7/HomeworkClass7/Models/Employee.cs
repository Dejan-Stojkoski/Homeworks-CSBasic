namespace Models
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public Role Role { get; set; }
        protected double Salary { get; set; }

        public Employee(string firstname, string lastname, Role role, double salary)
        {
            FirstName = firstname;
            LastName = lastname;
            Role = role;
            Salary = salary;
        }

        public string GetInfo()
        {
            return $"{FullName} - {Salary}";
        }

        public virtual double GetSalary()
        {
            return Salary;
        }
    }
}
