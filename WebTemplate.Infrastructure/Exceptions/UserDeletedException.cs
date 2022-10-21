using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTemplate.Infrastructure.Exceptions
{
    [Serializable]
    public class UserDeletedException:Exception
    {
        public UserDeletedException() { }
        
        public UserDeletedException(string? name) 
            : base($"Une erreur est survenue lors de la suppression de l'utilisateur: {name}") { }
        
        public UserDeletedException(string? message, Exception innerException) 
            : base(message, innerException) { }
    }
}
