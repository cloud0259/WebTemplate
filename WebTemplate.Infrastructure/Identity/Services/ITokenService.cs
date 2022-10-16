
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Infrastructure.Identity.Models;

namespace WebTemplate.Infrastructure.Identity.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> Authenticate(TokenRequest request);
    }
}
