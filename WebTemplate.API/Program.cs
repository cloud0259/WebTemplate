using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using WebTemplate.API.Config;
using WebTemplate.API.Modules;
using WebTemplate.Infrastructure.EntityFrameworkCore;
using WebTemplate.Infrastructure.Extensions;
using MediatR;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Autofac.Core;
using WebTemplate.Infrastructure.Identity.Services;
using WebTemplate.Domain.Users;
using WebTemplate.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.SetupSwagger(builder.Configuration);

builder.Services.SetAuthorization();

builder.Services.SetupDatabase(builder.Configuration);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        var module = new AutofacApiModule();
        builder.RegisterModule(module);

    });

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.SeedIdentityDataAsync().Wait();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers().RequireAuthorization();
});

app.Run();