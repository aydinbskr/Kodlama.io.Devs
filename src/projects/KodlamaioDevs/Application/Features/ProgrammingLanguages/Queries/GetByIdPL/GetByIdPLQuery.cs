using Application.Features.ProgrammingLanguages.Dtos;
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

namespace Application.Features.ProgrammingLanguages.Queries.GetByIdPL
{
    public class GetByIdPLQuery : IRequest<PLGetByIdDto>
    {
        public int Id { get; set; }

        public class GetListPLQueryHandler : IRequestHandler<GetByIdPLQuery, PLGetByIdDto>
        {
            private readonly IProgrammingLanguageRepository _PLRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguagesRules _PLBusinessRules;
            public GetListPLQueryHandler(IProgrammingLanguageRepository PLRepository, IMapper mapper, ProgrammingLanguagesRules PLBusinessRules)
            {
                _PLRepository = PLRepository;
                _mapper = mapper;
                _PLBusinessRules = PLBusinessRules;
            }

            public async Task<PLGetByIdDto> Handle(GetByIdPLQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? PL = await _PLRepository.GetAsync(b => b.Id == request.Id);

                _PLBusinessRules.PLShouldExistWhenRequested(PL);
                PLGetByIdDto mappedPLGetByIdDto = _mapper.Map<PLGetByIdDto>(PL);
                return mappedPLGetByIdDto;
            }
        }
    }
}
