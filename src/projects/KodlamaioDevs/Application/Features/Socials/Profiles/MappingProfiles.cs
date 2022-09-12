using Application.Features.Socials.Commands.CreateSocial;
using Application.Features.Socials.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApSocialication.Features.Socials.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Social, CreatedSocialDto>().ReverseMap();
            CreateMap<Social, CreateSocialCommand>().ReverseMap();

            CreateMap<Social, UpdatedSocialDto>().ReverseMap();
            //CreateMap<Social, UpdateSocialCommand>().ReverseMap();

            CreateMap<Social, DeletedSocialDto>().ReverseMap();
            //CreateMap<Social, DeleteSocialCommand>().ReverseMap();

            //CreateMap<IPaginate<Social>, SocialListModel>().ReverseMap();
           // CreateMap<Social, SocialListDto>().ReverseMap();
            //CreateMap<Social, SocialGetByIdDto>().ReverseMap();


        }
    }
}
