﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Domain.Users;
using WebTemplate.Infrastructure.Adapters;

namespace WebTemplate.Infrastructure.Identity.Models
{
    public class TokenResponse
    {
        public TokenResponse(ApplicationUser user,
                             string role,
                             string token
                            )
        {
            Id = user.Id;
            EmailAddress = user.Email;
            Token = token;
            Role = role;
        }

        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Token { get; set; }
        public string? Role { get; set; }
    }
}
