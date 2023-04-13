using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Core.Entities;

namespace WebTemplate.Domain.Users
{
    public class UserDetailsWithIdentityUser: EntityBase<Guid> 
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }

        public UserDetailsWithIdentityUser(
            Guid id,
            string userName,
            string firstName ,
            string lastName,
            string email, 
            string? address = null,
            string? zipCode = null,
            string? city = null)
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address = address;
            ZipCode = zipCode;
            City = city;
        }
    }
}
