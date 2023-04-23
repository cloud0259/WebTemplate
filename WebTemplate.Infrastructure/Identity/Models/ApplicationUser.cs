using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Domain;
using WebTemplate.Domain.Users;
using WebTemplate.Core.Entities;

namespace WebTemplate.Infrastructure.Identity.Models
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsEnabled { get; set; }
        public override string? Email { get; set; }

    }
}
