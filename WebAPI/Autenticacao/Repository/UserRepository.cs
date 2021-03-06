using System.Collections.Generic;
using System.Linq;
using Autenticacao.Models;

namespace Autenticacao.Repository
{
    public static class UserRepository
    {
        public static User Get(string username, string password){
            var users = new List<User>();

            users.Add(new User{
                UserId = 1,
                Username = "batman",
                Password = "batman",
                Role = "manager"
            });

            users.Add(new User{
                UserId = 2,
                Username = "robin",
                Password = "robin",
                Role = "employee"
            });

            return users.Where(
                x => x.Username.ToLower() == username.ToLower() &&
                x.Password == password).FirstOrDefault(); 
            
        }
    }
}