using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Core.Entities;
using WebTemplate.Core.Repositories;
using WebTemplate.Infrastructure.EntityFrameworkCore;
using WebTemplate.Infrastructure.EntityFrameworkCore.SoftDeletes;

namespace WebTemplate.Infrastructure.Repositories
{
    public class Repository<TEntity, TKey> :  IRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        public WebTemplateDbContext DbContext { get; }
        public IDataFilter DataFilter { get; }
        public Repository(WebTemplateDbContext dbContext, IDataFilter dataFilter)
        {
            DbContext = dbContext;
            DataFilter = dataFilter;
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            DbContext.Set<TEntity>().Remove(entity);
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var entities = await DbContext.Set<TEntity>().ToListAsync(cancellationToken);
            if (entities != null)
            {
                return entities;
            }
            return Enumerable.Empty<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var entities = await DbContext.Set<TEntity>().Where(expression).ToListAsync(cancellationToken);
            if (entities != null)
            {
                return entities;
            }
            return Enumerable.Empty<TEntity>();
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            var entity = await DbContext.Set<TEntity>().FirstOrDefaultAsync(expression, cancellationToken: cancellationToken);

            if (entity == null)
            {
                throw new Exception($"{typeof(TEntity)} as expression not found");
            }

            return entity;
        }

        public virtual async Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await DbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken: cancellationToken);

            if (entity == null)
            {
                throw new Exception($"{typeof(TEntity)} as expression not found");
            }

            return entity;
        }

        public virtual Task<(int,IEnumerable<TEntity>)> GetPagedList(int skipCount, int maxResultCount, string sorting, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                if (entity == null)
                {
                    throw new NullReferenceException($"{entity} is null");
                }

                await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
                await DbContext.SaveChangesAsync(cancellationToken);
                return entity;
            }
            catch (Exception ex)    
            {
                Log.Logger.Error(ex.Message);
                throw new Exception(ex.Message);
            }
            
        }

        public async Task InsertManyAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default)
        {
            if(entity is not null)
            {
                await DbContext.Set<TEntity>().AddRangeAsync(entity,cancellationToken);
            }
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var entitySave =  DbContext.Set<TEntity>().Update(entity);
            await DbContext.SaveChangesAsync(cancellationToken);
            return entitySave.Entity;
        }

        public Task UpdateManyAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task HardDeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            using(var t = DataFilter.Disable<ISoftDelete>())
            {
                DbContext.Remove(entity);
                await DbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
