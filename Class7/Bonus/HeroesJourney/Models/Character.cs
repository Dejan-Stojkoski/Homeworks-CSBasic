namespace Models
{
    public class Character
    {
        public string Name { get; set; }
        public Race Race { get; private set; }
        public Class Class { get; private set; }
        public int Health { get; private set; }
        public int Strength { get; private set; }
        public int Agility { get; private set; }

        public Character(string name, Race race, Class chosenClass)
        {
            Name = name;
            Race = race;
            Class = chosenClass;

            if (Race == Race.Dwarf)
            {
                Health = 100;
                Strength = 6;
                Agility = 2;
            }
            if (Race == Race.Elf)
            {
                Health = 60;
                Strength = 4;
                Agility = 6;
            }
            if (Race == Race.Human)
            {
                Health = 80;
                Strength = 5;
                Agility = 4;
            }

            if (Class == Class.Warrior)
            {
                Health += 20;
                Agility -= 1;
            }
            if (Class == Class.Rogue)
            {
                Health -= 20;
                Agility += 1;
            }
            if (Class == Class.Mage)
            {
                Health += 20;
                Strength -= 1;
            }
        }

        public string GetCharacterInfo()
        {
            return $"\nCharacter: {Name} ({Race}) the {Class}" +
                $"\nStats: {Health} HP, {Strength} STR, {Agility} AGI";
        }

        public void SetHealth(int health)
        {
            Health += health;
        }


    }
}
