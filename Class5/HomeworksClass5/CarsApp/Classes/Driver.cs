namespace CarsApp.Classes
{
    public class Driver
    {
        public string Name { get; set; }
        public int Skill { get; set; }

        public Driver() { }
        public Driver(string name, int skill)
        {
            Name = name;
            Skill = skill;
        }
    }
}
