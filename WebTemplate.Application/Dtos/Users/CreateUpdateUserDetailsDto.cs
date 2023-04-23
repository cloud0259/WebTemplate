using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTemplate.Application.Dtos.Users
{
    public class CreateUpdateUserDetailsDto
    {
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
    }
}
