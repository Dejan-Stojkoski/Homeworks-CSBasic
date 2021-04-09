namespace Models
{
    public class Contractor : Employee
    {
        public double WorkHours { get; set; }
        public int PayPerHour { get; set; }
        public Manager Responsible { get; set; }

        public Contractor(string firstname, string lastname, double workHours, int payPerHour, Manager responsible)
            : base(firstname, lastname, Role.Contractor, 0)
        {
            WorkHours = workHours;
            PayPerHour = payPerHour;
            Responsible = responsible;
        }

        public override double GetSalary()
        {
            double salary = WorkHours * PayPerHour;
            Salary = salary;
            return salary;
        }

        public string CurrentManager()
        {
            return Responsible.FullName;

            //CurrentPossition - WE DON'T HAVE A DEPARTMENT PROPERTY IN MANAGER NOR EMPLOYEE/ ARE WE SUPPOSED TO MAKE ONE?
        }
    }
}
