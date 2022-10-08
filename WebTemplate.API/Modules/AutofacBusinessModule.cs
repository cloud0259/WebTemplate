
using Autofac;
using System.Reflection;
using WebTemplate.Domain.Models;
using WebTemplate.Infrastructure.Repositories;

namespace WebTemplate.API.Modules
{
    public class AutofacBusinessModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           // builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterAssemblyTypes(Assembly.Load("WebTemplate.Infrastructure"))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces(); 

            builder.RegisterAssemblyTypes(Assembly.Load("WebTemplate.Application"))
                .Where(t => t.Name.EndsWith("AppService"))
                .AsImplementedInterfaces();
        }
    }
}
