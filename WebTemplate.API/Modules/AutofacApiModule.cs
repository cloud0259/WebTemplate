
using Autofac;
using System.Reflection;
using WebTemplate.Application;
using WebTemplate.Infrastructure;

namespace WebTemplate.API.Modules
{
    public class AutofacApiModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            /*  //Register an open generic repository => IRepository<TEntity,TKey>
              builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>));

              //Register the repositories on the infrastructure project
              builder.RegisterAssemblyTypes(Assembly.Load("WebTemplate.Infrastructure"))
                  .Where(t => t.Name.EndsWith("Repository"))
                  .AsImplementedInterfaces();

              //Register the services on the Application project
              builder.RegisterAssemblyTypes(Assembly.Load("WebTemplate.Application"))
                  .Where(t => t.Name.EndsWith("AppService"))
                  .AsImplementedInterfaces();*/

            builder.RegisterModule(new WebTemplateApplicationModule());
            builder.RegisterModule(new WebTemplateInfrastructureModule());
        }
    }
}
