using Microsoft.EntityFrameworkCore;
using WebTemplate.Core.Entities;
using System.Linq.Expressions;

namespace WebTemplate.Infrastructure.EntityFrameworkCore.SoftDeletes
{
    public static class SoftDeleteConfiguration
    {
        public static void ConfigureSoftDeleteFilter(this ModelBuilder modelBuilder, IDataFilter dataFilter)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var property = Expression.Property(parameter, "IsDeleted");
                    var isEnabled = Expression.Call(Expression.Constant(dataFilter), "IsEnabled", new[] { typeof(ISoftDelete) });
                    var notDeleted = Expression.Not(property);
                    var body = Expression.OrElse(Expression.Not(isEnabled), notDeleted);
                    var lambda = Expression.Lambda(body, parameter);
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }
        }
    }
}
