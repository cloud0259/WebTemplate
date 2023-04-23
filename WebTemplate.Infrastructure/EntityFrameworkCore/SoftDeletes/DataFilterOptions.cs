using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTemplate.Infrastructure.EntityFrameworkCore.SoftDeletes
{
    public class DataFilterOptions
    {
        public Dictionary<Type, DataFilterState> DefaultStates { get; }

        public DataFilterOptions()
        {
            DefaultStates = new Dictionary<Type, DataFilterState>();
        }
    }
}
