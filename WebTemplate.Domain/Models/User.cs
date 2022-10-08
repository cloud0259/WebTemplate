using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTemplate.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }

        protected User() { }

        public User(Guid id, string username, string name, string email, byte[]? passwordHash, byte[]? passwordSalt, DateTime created, DateTime lastUpdated)
        {
            Id = id;
            Username = username;
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Created = created;
            LastUpdated = lastUpdated;
        }   
    }
}
