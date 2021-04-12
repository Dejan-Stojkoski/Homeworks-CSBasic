namespace Models
{
    public class Event
    {
        public string Description { get; }
        public int Health { get; }

        public Event(string description, int health)
        {
            Description = description;
            Health = health;
        }
    }
}
