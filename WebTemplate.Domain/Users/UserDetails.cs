using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Core.Entities;
using WebTemplate.Domain;

namespace WebTemplate.Domain.Users
{
    public class UserDetails : FullAuditEntity<Guid>, IUserDetails<Guid>
    {
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get ; set ; }
        public Guid UserId { get; set; }

        protected UserDetails() { }
    }
}
