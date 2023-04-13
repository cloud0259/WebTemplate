using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Core.Entities;

namespace WebTemplate.Domain.Users 
 {
    public interface IUserDetails<T> : IEntityBase<T> 
    { 
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public T UserId { get; set; }
    }
}
