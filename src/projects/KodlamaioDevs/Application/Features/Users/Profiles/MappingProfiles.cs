using Application.Features.SystemUsers.Commands.UserRegister;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SystemUsers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserRegisterCommand>().ReverseMap();
            
        }
    }
}
