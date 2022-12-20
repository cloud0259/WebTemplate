using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebTemplate.API.Config;
using WebTemplate.API.Modules;
using WebTemplate.Infrastructure.EntityFrameworkCore;
using WebTemplate.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{

    var env = hostingContext.HostingEnvironment;

    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.SetupSwagger();
builder.Services.SetupAuthentication(builder.Configuration);
builder.Services.SetAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.SetupDatabase(builder.Configuration);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        var module = new AutofacApiModule();
        builder.RegisterModule(module);

    });

var app = builder.Build();
var context = app.Services.GetRequiredService<WebTemplateDbContext>();
context.Database.Migrate();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    /*app.UseSwagger();
    app.UseSwaggerUI();
    app.SeedIdentityDataAsync().Wait();*/
}

app.UseSwagger();
app.UseSwaggerUI();

app.SeedIdentityDataAsync().Wait();
app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers().RequireAuthorization();
});

app.Run();