using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTemplate.Infrastructure.Exceptions
{
    [Serializable]
    public class UserNotFoundException:Exception
    {
        public UserNotFoundException() { }

        public UserNotFoundException(string? id) : base($"L'utilisateur avec l'id {id} est introuvable") { }

        public UserNotFoundException(string? message, Exception innerException) : base(message, innerException) { }
    }
}
