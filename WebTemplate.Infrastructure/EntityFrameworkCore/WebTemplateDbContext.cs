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
using Microsoft.AspNetCore.Identity;
using WebTemplate.Infrastructure.Adapters;
using WebTemplate.Core.Entities;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using WebTemplate.Infrastructure.DependencyInjection;
using System.Collections.Concurrent;
using WebTemplate.Infrastructure.EntityFrameworkCore.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using WebTemplate.Infrastructure.EntityFrameworkCore.SoftDeletes;

namespace WebTemplate.Infrastructure.EntityFrameworkCore
{
    public class WebTemplateDbContext : WebTemplateBaseDbContext<WebTemplateDbContext>
    {
        public WebTemplateDbContext(DbContextOptions<WebTemplateDbContext> context) 
            : base(context)
        {
        }

        //Add DbSet 
        //Example: public DbSet<User> Users{get;set;}
        //public DbSet<User> Users { get; set; }
        public DbSet<Voiture>? Cars { get; set; }
        public DbSet<UserDetails>? UserDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Configure Soft Delete
            modelBuilder.ConfigureSoftDeleteFilter(DataFilter);

            modelBuilder.UseUserEntityConfiguration();

            /* applying the configuration
            modelBuilder.Entity<user>().ToTable("users");
            */
        }

        
    }
}
