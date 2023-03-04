using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebTemplate.Infrastructure.Exceptions
{
    [Serializable]
    public class UserUpdateException : Exception
    {
        public UserUpdateException()
        {
        }

        public UserUpdateException(string? name) 
            : base($"Une erreur est survenue lors de la mise à jour de l'utilisateur: {name}") {}

        public UserUpdateException(string? message, Exception? innerException) 
            : base(message, innerException){}
    }
}
