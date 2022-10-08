using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTemplate.Infrastructure.EntityFrameworkCore
{
    public class WebTemplateDbContextFactory : IDesignTimeDbContextFactory<WebTemplateDbContext>
    {
        public WebTemplateDbContext CreateDbContext(string[] args)
        {
            ConfigurationBuilder confBuilder = new ConfigurationBuilder();
            confBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.secret.json"));

            IConfigurationRoot configurationRoot = confBuilder.Build();

            var builder = new DbContextOptionsBuilder<WebTemplateDbContext>();

            builder.UseSqlServer(configurationRoot.GetConnectionString("DataBase"));

            WebTemplateDbContext context = new WebTemplateDbContext(builder.Options);

            return context;
        }
    }
}
