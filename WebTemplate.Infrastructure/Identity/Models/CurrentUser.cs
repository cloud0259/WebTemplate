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
        private readonly ClaimsIdentity _identity;

        public CurrentUser(IPrincipalProvider provider)
        {
            _identity = provider.User?.Identity as ClaimsIdentity ?? new ClaimsIdentity();
        }

        public bool IsAuthenticated => UserId.HasValue;
        public Guid? UserId => Guid.TryParse(_identity.Claims.FirstOrDefault(x => x.Type == WebTemplateClaimType.UserId)?.Value, out var userId) ? userId : null;
        public string Name => _identity.Claims.FirstOrDefault(c => c.Type == WebTemplateClaimType.Name)?.Value ?? string.Empty;
        public string Role => _identity.Claims.FirstOrDefault(c => c.Type == WebTemplateClaimType.Role)?.Value ?? string.Empty;
        public string Email => _identity.Claims.FirstOrDefault(x => x.Type == WebTemplateClaimType.Email)?.Value ?? string.Empty;
    }
}
