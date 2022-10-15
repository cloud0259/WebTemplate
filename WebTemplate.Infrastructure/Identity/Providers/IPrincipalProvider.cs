using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WebTemplate.Infrastructure.Identity.Providers
{
    public interface IPrincipalProvider
    {
        public IPrincipal User { get; } 
    }
}
