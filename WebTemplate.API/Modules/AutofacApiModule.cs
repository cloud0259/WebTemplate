using Autofac;
using Autofac.Core;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
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
            var configuration = MediatRConfigurationBuilder
            .Create(ThisAssembly)
            .WithAllOpenGenericHandlerTypesRegistered()
            .Build();

            builder.RegisterMediatR(configuration);
        }
    }
}
