using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Domain.Models;

namespace WebTemplate.Domain.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public abstract object[] GetKeys();

        public static explicit operator EntityBase(User v)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class EntityBase<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }

        public object[] GetKeys()
        {
            return new object[] { Id };
        }
    }
}
