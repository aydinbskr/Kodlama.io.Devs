using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguagesRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguagesRules(IProgrammingLanguageRepository brandRepository)
        {
            _programmingLanguageRepository = brandRepository;
        }

        public async Task PLNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("ProgrammingLanguage name exists.");
        }
        public void PLShouldExistWhenRequested(ProgrammingLanguage pl)
        {
            if (pl == null) throw new BusinessException("Requested ProgrammingLanguage does not exist.");
        }
    }
}
