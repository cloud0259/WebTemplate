using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Domain.Models;
using WebTemplate.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations;

namespace WebTemplate.Infrastructure.EntityFrameworkCore
{
    public class WebTemplateDbContext : DbContext
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
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());

            /* applying the configuration
            modelbuilder.entity<user>().totable("users");

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
