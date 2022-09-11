using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Commands.CreatePL;
using Application.Features.ProgrammingLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgrammingLanguages.Commands.UpdatePL;
using Application.Features.ProgrammingLanguages.Commands.DeletePL;

namespace Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguage, CreatedPLDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreatePLCommand>().ReverseMap();

            CreateMap<ProgrammingLanguage, UpdatedPLDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdatePLCommand>().ReverseMap();

            CreateMap<ProgrammingLanguage, DeletedPLDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeletePLCommand>().ReverseMap();

            CreateMap<IPaginate<ProgrammingLanguage>, PLListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, PLListDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, PLGetByIdDto>().ReverseMap();


        }
    }
}
