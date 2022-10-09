using System.Linq.Expressions;
using WebTemplate.Core.Entities;

namespace WebTemplate.Core.Repositories
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
        Task<IEnumerable<TEntity>> GetPagedList(int skipCount,
        int maxResultCount,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default);
        
    }
}
