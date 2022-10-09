using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Core.Repositories;
using WebTemplate.Infrastructure.Repositories;

namespace WebTemplate.Infrastructure
{
    public class WebTemplateInfrastructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Register an open generic repository => IRepository<TEntity,TKey>
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>));

            //Register the repositories on the infrastructure project
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
        }
    }
}
