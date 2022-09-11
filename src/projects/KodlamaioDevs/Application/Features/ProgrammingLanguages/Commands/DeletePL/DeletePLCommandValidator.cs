using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.DeletePL
{
    public class DeletePLCommandValidator : AbstractValidator<DeletePLCommand>
    {
        public DeletePLCommandValidator()
        {
            RuleFor(c => c.Id).NotNull();
        }
    }
}
