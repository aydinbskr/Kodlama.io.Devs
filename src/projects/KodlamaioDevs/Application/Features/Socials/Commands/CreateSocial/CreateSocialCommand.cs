using Application.Features.Socials.Dtos;
using Application.Features.Socials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Commands.CreateSocial
{
    public class CreateSocialCommand : IRequest<CreatedSocialDto>
    {
        public int UserId { get; set; }
        public string SocialUrl { get; set; }

        public class CreateSocialCommandHandler : IRequestHandler<CreateSocialCommand, CreatedSocialDto>
        {
            private readonly ISocialRepository _socialRepository;
            private readonly IMapper _mapper;
            private readonly SocialRules _socialBusinessRules;

            public CreateSocialCommandHandler(ISocialRepository socialRepository, IMapper mapper, SocialRules socialBusinessRules)
            {
                _socialRepository = socialRepository;
                _mapper = mapper;
                _socialBusinessRules = socialBusinessRules;
            }

            public async Task<CreatedSocialDto> Handle(CreateSocialCommand request, CancellationToken cancellationToken)
            {
                await _socialBusinessRules.SocialUrlCanNotBeDuplicatedWhenInserted(request.SocialUrl);

                Social mappedSocial = _mapper.Map<Social>(request);
                Social createdPL = await _socialRepository.AddAsync(mappedSocial);
                CreatedSocialDto createdSocialDto = _mapper.Map<CreatedSocialDto>(createdPL);

                return createdSocialDto;
            }
        }
    }
}
