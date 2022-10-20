using Autofac;
using Autofac.Core;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Core.Repositories;
using WebTemplate.Infrastructure.Identity.Models;
using WebTemplate.Infrastructure.Repositories;

namespace WebTemplate.Application.Modules
{
    public class WebTemplateApplicationAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Register the services on the Application project
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("AppService"))
                .PropertiesAutowired(propertySelector: new DefaultPropertySelector(false))
                .AsImplementedInterfaces();

            builder.RegisterAutoMapper(ThisAssembly);

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
        .As<IMapper>()
        .InstancePerLifetimeScope();
        }
    }
}
