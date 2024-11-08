using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Entities
{
    public class User
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        public User(string username, string password, string role = "User")
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }

}
