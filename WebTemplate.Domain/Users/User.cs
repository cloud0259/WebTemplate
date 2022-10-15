using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Core.Entities;
using WebTemplate.Domain;

namespace WebTemplate.Domain.Users
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public User(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }

        public object[] GetKeys()
        {
            return new object[] { Id };
        }
    }
}
