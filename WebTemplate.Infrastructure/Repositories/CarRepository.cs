using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Domain;
using WebTemplate.Infrastructure.EntityFrameworkCore;
using WebTemplate.Infrastructure.Repositories.Extensions;

namespace WebTemplate.Infrastructure.Repositories
{
    public class CarRepository : Repository<Voiture, Guid>, ICarRepository
    {
        public CarRepository(WebTemplateDbContext dbContext) 
            : base(dbContext)
        {
        }

        public async override Task<IEnumerable<Voiture>> GetAllAsync(bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            return await DbContext.Cars.IncludeDetails(includeDetails).ToListAsync(cancellationToken);
        }
    }
}
