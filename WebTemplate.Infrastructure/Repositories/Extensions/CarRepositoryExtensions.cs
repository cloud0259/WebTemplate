using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Domain;

namespace WebTemplate.Infrastructure.Repositories.Extensions
{
    public static class CarRepositoryExtensions
    {
        public static IQueryable<Voiture> IncludeDetails(
            this IQueryable<Voiture> query,
            bool includeDetails = false)
        {
            if (!includeDetails)
            {
                return query;
            }

            return query;
            //return query.Include(x => x.User);
        }
    }
}
