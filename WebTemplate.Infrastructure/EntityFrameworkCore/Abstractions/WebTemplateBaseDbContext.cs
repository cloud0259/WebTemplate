using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Infrastructure.Identity.Models;
using WebTemplate.Core.Entities;
using WebTemplate.Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebTemplate.Core.Contracts;
using WebTemplate.Infrastructure.EntityFrameworkCore.SoftDeletes;

namespace WebTemplate.Infrastructure.EntityFrameworkCore.Abstractions
{
    public abstract class WebTemplateBaseDbContext<TDbContext> : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>, IWebTemplateBaseDbContext, ITransientDependency
        where TDbContext : DbContext
    {
        public WebTemplateBaseDbContext()
        {
        }

        protected WebTemplateBaseDbContext(DbContextOptions<TDbContext> context) 
            : base(context) 
        {

        }

        public ILazyServiceProvider LazyServiceProvider { get; set; }
        protected ICurrentUser CurrentUser => LazyServiceProvider.LazyGetRequiredService<ICurrentUser>();
        protected IDataFilter DataFilter => LazyServiceProvider.LazyGetRequiredService<IDataFilter>();

        public override int SaveChanges()
        {
            AddAndUpdateEntities();
            UseSoftDelete();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddAndUpdateEntities();
            UseSoftDelete();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddAndUpdateEntities()
        {
            var id = CurrentUser.IsAuthenticated ? CurrentUser.UserId.ToString() : null;
            foreach (var entry in ChangeTracker.Entries<IAuditEntity>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                entry.Entity.UpdatedDate = DateTime.UtcNow;
                entry.Entity.UpdatedBy = id;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    entry.Entity.CreatedBy = id;
                }
            }
        }

        private void UseSoftDelete()
        {
            if (DataFilter.IsEnabled<ISoftDelete>())
            {
                foreach (var entry in ChangeTracker.Entries<ISoftDelete>().Where(e => e.State == EntityState.Deleted))
                {
                    entry.Entity.IsDeleted = true;
                    entry.CurrentValues.SetValues(new { IsDeleted = true });
                    entry.State = EntityState.Unchanged;
                }
            }            
        }

    }
}
