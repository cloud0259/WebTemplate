using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Application.Dtos.Users;
using WebTemplate.Domain.Users;

namespace WebTemplate.Application
{
    public class WebTemplateAutoMapperProfile:Profile
    {
        public WebTemplateAutoMapperProfile() 
        {
            CreateMap<CreateUpdateUserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
