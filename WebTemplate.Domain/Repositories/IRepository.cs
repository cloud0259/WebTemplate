using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Domain.Entities;
using WebTemplate.Domain.Models;

namespace WebTemplate.Domain.Repositories
{
    public interface IRepository<TEntity,TKey>  where TEntity : EntityBase<TKey>
    {
        Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default);
        Task<TEntity> GetAsync(Expression<Func<TEntity,bool>> expression, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, bool includeDetails = false, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAllAsync(bool includeDetails = false, CancellationToken cancellationToken= default);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, bool includeDetails = false, CancellationToken cancellationToken = default);
    }
}
