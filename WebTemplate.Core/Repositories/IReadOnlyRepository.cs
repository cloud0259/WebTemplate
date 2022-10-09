using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Core.Entities;

namespace WebTemplate.Core.Repositories
{
    public interface IReadOnlyRepository<TEntity,TKey> where TEntity : EntityBase<TKey>
    {
        Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default); 
        Task<IEnumerable<TEntity>> GetAllAsync(bool includeDetails = false, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, bool includeDetails = false, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetPagedList(int skipCount,
        int maxResultCount,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default);
    }
}
