namespace CarsApp.Classes
{
    public class Car
    {
        public string Model { get; set; }
        public int Speed { get; set; }
        public Driver Driver { get; set; }

        public int CalculateSpeed()
        {
            return Speed * Driver.Skill;
        }

        public Car() { }
        public Car(string model, int speed)
        {
            Model = model;
            Speed = speed;
        }
    }
}
