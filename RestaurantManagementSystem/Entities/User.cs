﻿using System;

namespace RestaurantManagementSystem.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User(int id, string username, string password, string role = "User")
        {
            Id = id;
            Username = username;
            Password = password;
            Role = role;
        }

        // Entity Framework üçün parameterless konstruktor tələb olunur
        public User() { }
    }
}
