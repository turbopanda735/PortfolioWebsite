namespace LoginAPI.Models
{
    public class User
    {
        public User(string username, string password)
        {
            Username = username;
            Password = password;
            LoggedIn = false;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public bool LoggedIn { get; set; }
        public Cards? Cards { get; set; }
    }
}
