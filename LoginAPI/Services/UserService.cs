using LoginAPI.Models;
using movieProject.Models.Movie;
using System.Xml.Linq;

namespace LoginAPI.Services
{
    public static class UserService
    {
        static List<User> Users { get; }
        static UserService()
        {
            Users = new List<User>();
        }
        public static List<User> GetAll() => Users;
        public static User Get(string username)
        {
            return (User)Users.Where(x => x.Username.Contains($"{username}"));
        }

        public static User Add(string username, string password)
        {
            return new User(username, password);
        }

        public static void Delete(User user)
        {
            Users.Remove(user);
        }

        public static void Update(User user, string password)
        {
            user.Password = password;
        }
    }
}
