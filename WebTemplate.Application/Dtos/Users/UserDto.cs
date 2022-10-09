using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Core.Entities;
using WebTemplate.Domain;

namespace WebTemplate.Application.Dtos.Users
{
    public class UserDto:FullAuditEntity<Guid>
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Voiture Voiture { get; set; }
        public Guid? VoitureId { get; set; }
    }
}
