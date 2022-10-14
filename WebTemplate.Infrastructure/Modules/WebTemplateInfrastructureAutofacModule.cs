using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Core.Repositories;
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
            builder.RegisterType(typeof(CurrentUser)).As(typeof(ICurrentUser));
            builder.RegisterType(typeof(DefaultPrincipalProvider)).As(typeof(IPrincipalProvider));
            
            //Register the repositories on the infrastructure project
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Manager"))
                .AsImplementedInterfaces();
        }
    }
}
