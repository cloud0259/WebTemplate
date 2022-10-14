using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTemplate.Core.Constants
{
    public static class ApplicationIdentityConstants
    {
        /// <summary>
        /// Roles for the identity roles
        /// </summary>
        public static class Roles
        {
            public static readonly string Administrator = "Administrator";
            public static readonly string Member = "Member";

            public static readonly string[] RolesSupported = { Administrator, Member };
        }

        /// <summary>
        /// Default password for the first user
        /// </summary>
        public static readonly string DefaultPassword = "Password@1";
    }
}
