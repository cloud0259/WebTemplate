using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Domain.Users;
using WebTemplate.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebTemplate.Infrastructure.Identity.Models;
using WebTemplate.Domain;
using System.Reflection.Emit;

namespace WebTemplate.Infrastructure.EntityFrameworkCore
{
    public class WebTemplateDbContext : IdentityDbContext<ApplicationUser>
    {
        protected WebTemplateDbContext()
        {
        }

        public WebTemplateDbContext(DbContextOptions<WebTemplateDbContext> options) 
            : base(options) 
        {

        }

        //Add DbSet 
        //Example: public DbSet<User> Users{get;set;}
        //public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());

            /* applying the configuration
            modelBuilder.Entity<user>().ToTable("users");

            or use entitytypeconfiguration file on entitytypeconfigurations folder
            this file
            modelbuilder.applyconfiguration(new userentitytypeconfiguration());

            public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
            {
               public void Configure(EntityTypeBuilder<User> builder)
               {
                   builder.ToTable("Users");
                   //Add entity configuration
               }
            }*/
        }
    }
}
