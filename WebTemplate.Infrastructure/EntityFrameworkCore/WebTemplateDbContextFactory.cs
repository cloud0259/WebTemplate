using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Infrastructure.DependencyInjection;
using WebTemplate.Infrastructure.EntityFrameworkCore.SoftDeletes;

namespace WebTemplate.Infrastructure.EntityFrameworkCore
{
    public class WebTemplateDbContextFactory : IDesignTimeDbContextFactory<WebTemplateDbContext>
    {
        public WebTemplateDbContext CreateDbContext(string[] args)
        {
            ConfigurationBuilder confBuilder = new ConfigurationBuilder();
            confBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Production.json"),true)
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.secret.json"),true);

            IConfigurationRoot configurationRoot = confBuilder.Build();

            var builder = new DbContextOptionsBuilder<WebTemplateDbContext>();

            builder.UseSqlServer(configurationRoot.GetConnectionString("DataBase"));
            var services = new ServiceCollection();
            // Ajoutez les services nécessaires à votre conteneur de services
            services.AddTransient<IDataFilter, DataFilter>();
            // Ajoutez d'autres services...

            // Créez un fournisseur de services avec les services configurés
            var serviceProvider = services.BuildServiceProvider();

            WebTemplateDbContext context = new WebTemplateDbContext(builder.Options);
            context.LazyServiceProvider = new LazyServiceProvider(serviceProvider);
            return context;
        }
    }
}
