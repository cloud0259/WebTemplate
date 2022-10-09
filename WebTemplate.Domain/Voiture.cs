using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Core.Entities;

namespace WebTemplate.Domain
{
    public class Voiture : FullAuditEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
