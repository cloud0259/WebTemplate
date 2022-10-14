using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebTemplate.Domain.Users;
using WebTemplate.Infrastructure.EntityFrameworkCore;
using WebTemplate.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Identity;
using WebTemplate.Infrastructure.Identity.Models;

namespace WebTemplate.API.Config
{
    public static class DataBaseConfig
    {
        public static void SetupDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WebTemplateDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Database"))
            );

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddDefaultTokenProviders()
                    .AddUserManager<UserManager<ApplicationUser>>()
                    .AddSignInManager<SignInManager<ApplicationUser>>()
                    .AddEntityFrameworkStores<WebTemplateDbContext>();
            services.Configure<IdentityOptions>(
                options =>
                {
                    options.SignIn.RequireConfirmedEmail = true;
                    options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

                    // Identity : Default password settings
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 1;
                });

            // services required using Identity
            services.AddScoped<ITokenService, TokenService>();

        }
    }
}
