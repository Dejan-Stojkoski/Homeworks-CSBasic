namespace Models
{
    public class User
    {
        public string Email { get; private set; }
        private string Password { get; set; }
        public Character Character { get; private set; }

        public User(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public string GetPassword()
        {
            return Password;
        }

        public void SetCharacter(Character character)
        {
            Character = character;
        }
    }
}
