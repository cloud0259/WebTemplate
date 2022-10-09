using System.Linq.Expressions;
using WebTemplate.Core.Entities;

namespace WebTemplate.Core.Repositories
{
    public interface IRepository<TEntity,TKey>: IReadOnlyRepository<TEntity,TKey> where TEntity : EntityBase<TKey>
    {
        Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> InsertManyAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, bool includeDetails = false, CancellationToken cancellationToken = default);
        Task<TEntity> UpdateManyAsync(IEnumerable<TEntity> entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default); 
    }
}
