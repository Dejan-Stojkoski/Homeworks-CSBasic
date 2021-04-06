using System;
using CarsApp.Classes;

namespace CarsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver[] drivers = new Driver[4];
            drivers[0] = new Driver("Bob", 5);
            drivers[1] = new Driver("Greg", 7);
            drivers[2] = new Driver("Jill", 9);
            drivers[3] = new Driver("Anne", 10);

            Car[] cars = new Car[4];
            cars[0] = new Car("Hyundai", 230);
            cars[1] = new Car("Mazda", 240);
            cars[2] = new Car("Ferrari", 300);
            cars[3] = new Car("Porsche", 304);

            Car car1, car2;
            string check;

            do
            {
                Console.WriteLine("Choose car and driver no.1 : ");
                car1 = ChooseCarAndDriver(cars, drivers);

                Console.WriteLine("\nChoose car and driver no.2 : ");
                car2 = ChooseCarAndDriver(cars, drivers);

                while (true)
                {
                    if (car1.Model == car2.Model)
                    {
                        Console.WriteLine($"\nYou can't have one vehicle compete! Enter new vehicle, instead of {car2.Model}: ");
                        car2 = ChooseCarAndDriver(cars, drivers);
                    }
                    else break;
                }

                while (true)
                {
                    if (car1.Driver.Name == car2.Driver.Name)
                    {
                        Console.WriteLine($"\nYou can't have the same driver drive both vehicles! Enter new driver, instead of {car2.Driver.Name}: ");
                        car2 = ChooseCarAndDriver(cars, drivers);
                    }
                    else break;
                }

                Console.WriteLine(RaceCars(car1, car2));

                Console.Write("\nIf you want to race again write Y, if you want to quit write anything: ");
                check = Console.ReadLine();
                Console.WriteLine("");
            }
            while (check.ToLower() == "y");
            
    }

        static string RaceCars(Car car1, Car car2)
        {
            Car winner;

            if (car1.CalculateSpeed() > car2.CalculateSpeed()) winner = car1;
            else winner = car2;

            return $"\nThe model {winner.Model} was faster. It was going with a speed of {winner.CalculateSpeed()} and it was driven by {winner.Driver.Name}.";

        }

        static Car ChooseCarAndDriver(Car [] cars, Driver [] drivers)
        {
            Car carForRace = new Car();
            int temp = 0;

            while (true)
            {
                Console.Write("Enter car model (Hyundai, Mazda, Ferrari, Porsche): ");
                string carInput = Console.ReadLine();

                foreach (Car car in cars)
                {
                    if (carInput.ToLower() == car.Model.ToLower())
                    {
                        carForRace = car;
                        temp++;
                        break;
                    }
                }

                if(temp == 1)
                {
                    while (true)
                    {
                        Console.Write("Enter driver name (Bob, Greg, Jill, Anne): ");
                        string driverInput = Console.ReadLine();

                        foreach(Driver driver in drivers)
                        {
                            if(driver.Name.ToLower() == driverInput.ToLower())
                            {
                                carForRace.Driver = driver;
                                temp++;
                                break;
                            }
                        }

                        if (temp == 2) break;
                        else Console.Write("Wrong driver name! Please try again. ");
                    }
                }

                if (temp == 0) Console.Write("There is no such car! Try again. ");
                else break;
            }

            return carForRace;
        }
    }
}
