using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTemplate.Infrastructure.EntityFrameworkCore.SoftDeletes
{
    public class DataFilterState
    {
        public bool IsEnabled { get; set; }

        public DataFilterState(bool isEnabled)
        {
            IsEnabled = isEnabled;
        }

        public DataFilterState Clone()
        {
            return new DataFilterState(IsEnabled);
        }
    }
}
