using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Domain;

namespace WebTemplate.Application.Dtos.Users
{
    public class CreateUpdateUserDto
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public Guid? VoitureId { get; set; }
    }
}
