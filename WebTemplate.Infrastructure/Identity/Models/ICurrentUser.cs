using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTemplate.Infrastructure.Identity.Models
{
    public interface ICurrentUser
    {
        bool IsAuthenticated { get; }       
        string UserId { get; }
        string Name { get; }
        string Role { get; }
        string Email { get; }
    }
}
