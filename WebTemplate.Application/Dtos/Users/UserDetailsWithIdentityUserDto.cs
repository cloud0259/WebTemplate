using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTemplate.Application.Dtos.Users
{
    public class UserDetailsWithIdentityUserDto
    {
        public string UserName { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
    }
}
