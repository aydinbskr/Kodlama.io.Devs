using Application.Features.ProgrammingLanguages.Dtos;
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
    public class DeletePLCommand : IRequest<DeletedPLDto>
    {
        public int Id { get; set; }

        public class DeleteBrandCommandHandler : IRequestHandler<DeletePLCommand, DeletedPLDto>
        {
            private readonly IProgrammingLanguageRepository _plRepository;
            private readonly IMapper _mapper;
           

            public DeleteBrandCommandHandler(IProgrammingLanguageRepository plRepository, IMapper mapper)
            {
                _plRepository = plRepository;
                _mapper = mapper;
                
            }

            public async Task<DeletedPLDto> Handle(DeletePLCommand request, CancellationToken cancellationToken)
            {
                

                ProgrammingLanguage mappedPL = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage deletedPL = await _plRepository.DeleteAsync(mappedPL);
                DeletedPLDto deletedPLDto = _mapper.Map<DeletedPLDto>(deletedPL);

                return deletedPLDto;
            }
        }
    }
}
