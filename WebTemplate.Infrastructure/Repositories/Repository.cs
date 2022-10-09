using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Core.Entities;
using WebTemplate.Core.Repositories;
using WebTemplate.Infrastructure.EntityFrameworkCore;

namespace WebTemplate.Infrastructure.Repositories
{
    public class Repository<TEntity, TKey> :  IRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        private readonly WebTemplateDbContext _dbContext;

        public Repository(WebTemplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var entities = await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);
            if (entities != null)
            {
                return entities;
            }
            return Enumerable.Empty<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var entities = await _dbContext.Set<TEntity>().Where(expression).ToListAsync(cancellationToken);
            if (entities != null)
            {
                return entities;
            }
            return Enumerable.Empty<TEntity>();
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            var entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(expression, cancellationToken: cancellationToken);

            var t = _dbContext.Entry<TEntity>(entity).Navigations.ToList();
            if (entity == null)
            {
                throw new Exception($"{typeof(TEntity)} as expression not found");
            }

            return entity;
        }

        public virtual async Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x=>x.Id.Equals(id), cancellationToken: cancellationToken);

            if (entity == null)
            {
                throw new Exception($"{typeof(TEntity)} as  expression not found");
            }

            return entity;
        }

        public Task<IEnumerable<TEntity>> GetPagedList(int skipCount, int maxResultCount, string sorting, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            if(entity == null)
            {
                throw new NullReferenceException($"{entity} is null");
            }

            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateAsync(TEntity entity, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
