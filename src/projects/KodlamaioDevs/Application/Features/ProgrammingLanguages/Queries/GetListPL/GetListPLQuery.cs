using Application.Features.ProgrammingLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetListPL
{
    public class GetListPLQuery : IRequest<PLListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListPLQueryHandler : IRequestHandler<GetListPLQuery, PLListModel>
        {
            private readonly IProgrammingLanguageRepository _PLRepository;
            private readonly IMapper _mapper;

            public GetListPLQueryHandler(IProgrammingLanguageRepository PLRepository, IMapper mapper)
            {
                _PLRepository = PLRepository;
                _mapper = mapper;
               
            }

            public async Task<PLListModel> Handle(GetListPLQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguage> PLs = await _PLRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                PLListModel mappedPLListModel = _mapper.Map<PLListModel>(PLs);
                return mappedPLListModel;
            }
        }
    }
}
