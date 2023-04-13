using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WebTemplate.Infrastructure.Identity.Security.Claims
{
    public static class WebTemplateClaimType
    {
        public static string UserId => "UserId";
        public static string Name => "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
        public static string Role => "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
        public static string Email =>"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
    }
}
