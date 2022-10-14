using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WebTemplate.Infrastructure.Identity.Providers
{
    public class DefaultPrincipalProvider : IPrincipalProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public DefaultPrincipalProvider(IHttpContextAccessor httpContextAccessor) 
        {
            _contextAccessor = httpContextAccessor;
        }
        public IPrincipal User => _contextAccessor.HttpContext.User;
    }
}
