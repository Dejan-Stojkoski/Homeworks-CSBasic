using System;
using Models;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Bob", "Bobsky", Role.Others, 600);
            SalesPerson salesPerson = new SalesPerson("Bill", "Bilsky", 1500);
            Manager manager = new Manager("Elon", "Musk", 5000);

            salesPerson.ExtendSuccessRevenue(2000);
            manager.AddBonus(4000);
            salesPerson.ExtendSuccessRevenue(3000);

            Console.WriteLine(employee.GetInfo());
            Console.WriteLine(salesPerson.GetInfo());
            Console.WriteLine(manager.GetInfo());

            Console.WriteLine($"Employee salary: {employee.GetSalary()}");
            Console.WriteLine($"Sales person salary: {salesPerson.GetSalary()}");
            Console.WriteLine($"Manager salary: {manager.GetSalary()}");


            Contractor contractor = new Contractor("Greg", "Gregsky", 40, 50, manager);

            Console.WriteLine($"Contractor current manager: {contractor.CurrentManager()}");
            Console.WriteLine($"Manager salary: {contractor.GetSalary()}");



            Employee[] company = new Employee[5]
            {
                new Contractor("Bill", "Bilsky", 38, 55, manager),
                new Contractor("Mallory", "Monroe", 44, 60, manager),
                new Manager("Scot", "Scotsky", 1000),
                new Manager("Ben", "Bensky", 2000),
                new SalesPerson("Jill", "Jillsky",1500)
            };

            CEO ceo = new CEO("Ron", "Ronsky", 1500, company);

            Console.WriteLine($"\n\nCEO: {ceo.GetInfo()}");
            Console.WriteLine("Employees: ");
            foreach(string employee1 in ceo.GetEmployees())
            {
                Console.WriteLine(employee1);
            }

            Console.WriteLine(ceo.GetSalary());

            ceo.SetShares(30);
            ceo.AddSharesPrice(500);

            Console.WriteLine($"CEO sallary with shares: {ceo.GetSalary()}");
        }
    }
}
