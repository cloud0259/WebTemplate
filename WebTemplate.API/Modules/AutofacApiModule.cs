using Autofac;
using System.Reflection;
using WebTemplate.Application.Modules;
using WebTemplate.Infrastructure.Modules;

namespace WebTemplate.API.Modules
{
    public class AutofacApiModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new WebTemplateApplicationAutofacModule());
            builder.RegisterModule(new WebTemplateInfrastructureAutofacModule());
        }
    }
}
