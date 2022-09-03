using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.DeletePL
{
    public class DeletePLCommand : IRequest<CreatedPLDto>
    {
        public int Id { get; set; }

        public class DeleteBrandCommandHandler : IRequestHandler<DeletePLCommand, CreatedPLDto>
        {
            private readonly IProgrammingLanguageRepository _plRepository;
            private readonly IMapper _mapper;
           

            public DeleteBrandCommandHandler(IProgrammingLanguageRepository plRepository, IMapper mapper)
            {
                _plRepository = plRepository;
                _mapper = mapper;
                
            }

            public async Task<CreatedPLDto> Handle(DeletePLCommand request, CancellationToken cancellationToken)
            {
                

                ProgrammingLanguage mappedPL = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage deletedPL = await _plRepository.DeleteAsync(mappedPL);
                CreatedPLDto createdPLDto = _mapper.Map<CreatedPLDto>(deletedPL);

                return createdPLDto;
            }
        }
    }
}
