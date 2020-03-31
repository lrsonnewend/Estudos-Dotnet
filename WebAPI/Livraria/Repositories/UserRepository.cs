using System.Collections.Generic;
using System.Linq;
using Livraria.Models;

namespace Livraria.Repository
{
    public static class UserRepository
    {
        public static User Get(string username, string password){
            var users = new List<User>();

            users.Add(new User{
                UserId = 1,
                Username = "admin",
                Password = "admin",
                Roles = "root"
            });

            users.Add( new User{
                UserId = 2,
                Username = "standard",
                Password = "standard",
                Roles = "reader"
            });

            return users.Where(
                x => x.Username.ToLower() == username.ToLower() &&
                x.Password == password).FirstOrDefault(); 
            
        }
    }
}