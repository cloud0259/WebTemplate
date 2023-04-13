using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Infrastructure.Identity.Providers;
using WebTemplate.Infrastructure.Identity.Security.Claims;

namespace WebTemplate.Infrastructure.Identity.Models
{
    public class CurrentUser : ICurrentUser
    {
        private readonly ClaimsIdentity? _identity;

        public CurrentUser(IPrincipalProvider provider)
        {
            _identity = provider.User.Identity as ClaimsIdentity;
        }

        public bool IsAuthenticated => _identity!.IsAuthenticated;
        public Guid UserId => Guid.Parse(_identity!.Claims.First(x => x.Type! == WebTemplateClaimType.UserId).Value);
        public string Name => _identity!.Claims.First(c => c.Type == WebTemplateClaimType.Name).Value;
        public string Role => _identity!.Claims.First(c => c.Type == WebTemplateClaimType.Role).Value;
        public string Email => _identity!.Claims.First(x => x.Type == WebTemplateClaimType.Email).Value;
    }
}
