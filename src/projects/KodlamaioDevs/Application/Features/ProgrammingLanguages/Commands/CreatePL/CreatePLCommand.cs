using Application.Features.Brands.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.CreatePL
{
    public class CreatePLCommand : IRequest<CreatedPLDto>
    {
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreatePLCommand, CreatedPLDto>
        {
            private readonly IProgrammingLanguageRepository _plRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguagesRules _plBusinessRules;

            public CreateBrandCommandHandler(IProgrammingLanguageRepository plRepository, IMapper mapper, ProgrammingLanguagesRules plBusinessRules)
            {
                _plRepository = plRepository;
                _mapper = mapper;
                _plBusinessRules = plBusinessRules;
            }

            public async Task<CreatedPLDto> Handle(CreatePLCommand request, CancellationToken cancellationToken)
            {
                await _plBusinessRules.PLNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgrammingLanguage mappedPL = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage createdPL = await _plRepository.AddAsync(mappedPL);
                CreatedPLDto createdPLDto = _mapper.Map<CreatedPLDto>(createdPL);

                return createdPLDto;
            }
        }
    }
}
