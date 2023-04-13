using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Core.Entities;
using WebTemplate.Domain.Users;

namespace WebTemplate.Domain
{
    public class Voiture : AuditEntity<Guid>
    {
        public string Name { get; set; }
    }
}
