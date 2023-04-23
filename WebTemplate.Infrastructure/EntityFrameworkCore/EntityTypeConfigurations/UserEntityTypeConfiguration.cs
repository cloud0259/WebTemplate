using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Domain.Users;

namespace WebTemplate.Infrastructure.EntityFrameworkCore.EntityTypeConfigurations
{
    //public class UserEntityTypeConfiguration : IEntityTypeConfiguration<UserDetails>
    //{
    //    public void Configure(EntityTypeBuilder<UserDetails> builder)
    //    {
    //        builder.ToTable("UserDetails");
    //    }
    //}

    public static class UserEntityTypeConfigurationExtension
    {
        public static void UseUserEntityConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetails>(u =>
            {
                u.ToTable("UserDetails");
            });
        }
    }
    
}
