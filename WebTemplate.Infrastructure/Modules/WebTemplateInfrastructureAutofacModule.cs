using Autofac;
using Autofac.Core;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Serilog.Configuration;
using Serilog.Extensions.Autofac.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Core.Contracts;
using WebTemplate.Core.Entities;
using WebTemplate.Core.Repositories;
using WebTemplate.Infrastructure.DependencyInjection;
using WebTemplate.Infrastructure.EntityFrameworkCore;
using WebTemplate.Infrastructure.EntityFrameworkCore.Abstractions;
using WebTemplate.Infrastructure.EntityFrameworkCore.SoftDeletes;
using WebTemplate.Infrastructure.Identity.Models;
using WebTemplate.Infrastructure.Identity.Providers;
using WebTemplate.Infrastructure.Repositories;

namespace WebTemplate.Infrastructure.Modules
{
    public class WebTemplateInfrastructureAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Register an open generic repository => IRepository<TEntity,TKey>
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>));
            builder.RegisterType(typeof(LazyServiceProvider)).As(typeof(ILazyServiceProvider));
            //Register Current User 
            builder.RegisterType(typeof(CurrentUser)).As(typeof(ICurrentUser));
            builder.RegisterType(typeof(DefaultPrincipalProvider)).As(typeof(IPrincipalProvider));

            //DataFilter
            builder.RegisterGeneric(typeof(DataFilter<>)).As(typeof(IDataFilter<>));
            builder.RegisterType(typeof(DataFilter)).As(typeof(IDataFilter)).SingleInstance();

            builder.RegisterAssemblyTypes(typeof(WebTemplateBaseDbContext<>).Assembly)
                   .Where(t => t.IsAssignableTo<WebTemplateBaseDbContext<WebTemplateDbContext>>())
                   .PropertiesAutowired(propertySelector: new DefaultPropertySelector(false))
                   .AsSelf()
                   .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.GetInterfaces().Contains(typeof(ITransientDependency)))
                .PropertiesAutowired(propertySelector: new DefaultPropertySelector(false))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Adapter"))
                .AsImplementedInterfaces();

            //Register the repositories on the infrastructure project
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            builder.RegisterSerilog(new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("Log/Log.txt"));
        }
    }
}
