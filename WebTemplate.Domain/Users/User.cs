using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Core.Entities;
using WebTemplate.Domain;

namespace WebTemplate.Domain.Users
{
    public class User:FullAuditEntity<Guid>
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public Voiture Voiture { get; set; }
        public Guid? VoitureId { get; set; }
        protected User() { }

        public User(string username, string name, string email)
        {
            Username = username;
            Name = name;
            Email = email;
        }
    }
}
