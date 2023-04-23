using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Domain.Users;
using Microsoft.AspNetCore.Identity;
using WebTemplate.Infrastructure.Identity.Models;
using Microsoft.Extensions.FileProviders;
using WebTemplate.Infrastructure.Adapters;

namespace WebTemplate.Infrastructure.Identity.Services
{
    public class TokenService : ITokenService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Token _token;
        private readonly HttpContext _httpContext;

        /// <inheritdoc cref="ITokenService" />
        public TokenService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<Token> tokenOptions,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _token = tokenOptions.Value;
            _httpContext = httpContextAccessor.HttpContext;
        }

        /// <inheritdoc cref="ITokenService.Authenticate(TokenRequest, string)"/>
        public async Task<TokenResponse> Authenticate(TokenRequest request)
        {
            if (await IsValidUser(request.Username!, request.Password!))
            {
                ApplicationUser user = await GetUserByEmail(request.Username!);

                if (user != null && user.IsEnabled)
                {
                    string role = (await _userManager.GetRolesAsync(user))[0];
                    string jwtToken = await GenerateJwtToken(user);

                    await _userManager.UpdateAsync(user);

                    return new TokenResponse(user,
                                             role,
                                             jwtToken
                                             );
                }
            }

            return null;
        }

        private async Task<bool> IsValidUser(string username, string password)
        {
            ApplicationUser user = await GetUserByEmail(username);

            if (user == null)
            {
                // Username or password was incorrect.
                return false;
            }

            //If you need cookies, please use PasswordSignInAsync(username, password, true,false);  
            //SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, password, true, false);

            SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(user, password,false);

            return signInResult.Succeeded;
        }

        private async Task<ApplicationUser> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            string role = (await _userManager.GetRolesAsync(user))[0];
            byte[] secret = Encoding.ASCII.GetBytes(_token.Secret!);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Issuer = _token.Issuer,
                Audience = _token.Audience,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("FullName", $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_token.Expiry),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = handler.CreateToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}