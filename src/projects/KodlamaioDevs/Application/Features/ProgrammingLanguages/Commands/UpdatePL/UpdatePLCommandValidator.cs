using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.UpdatePL
{
    public class UpdatePLCommandValidator : AbstractValidator<UpdatePLCommand>
    {
        public UpdatePLCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.Name).MinimumLength(2);
        }
    }
}
