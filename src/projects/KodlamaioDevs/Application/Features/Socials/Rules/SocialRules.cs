using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Socials.Rules
{
    public class SocialRules
    {
        private readonly ISocialRepository _socialRepository;

        public SocialRules(ISocialRepository brandRepository)
        {
            _socialRepository = brandRepository;
        }

        public async Task SocialUrlCanNotBeDuplicatedWhenInserted(string url)
        {
            IPaginate<Social> result = await _socialRepository.GetListAsync(b => b.SocialUrl == url);
            if (result.Items.Any()) throw new BusinessException("Social name exists.");
        }
        public void SocialShouldExistWhenRequested(ProgrammingLanguage pl)
        {
            if (pl == null) throw new BusinessException("Requested Social does not exist.");
        }
    }
}
