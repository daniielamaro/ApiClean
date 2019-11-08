using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validations
{
    class PublicationValidator : AbstractValidator<Publication.publication>
    {
        public PublicationValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O Id não pode ser nulo.")
                .NotEqual(new Guid());
                .WithMessage("O Id não pode ser um Guid vazio (zerado).");

            RuleFor(x => x.Autor.Id)
                .SetValidator(new UserExistValidator());

            RuleFor(x => x.Title)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O titulo não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O titulo não pode estar em branco.")
                .MaximumLength(20);

            RuleFor(x => x.Content)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O conteudo não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O conteudo não pode estar em branco.");

            RuleFor(x => x.Topic.Id)
                .SetValidator(new TopicExistValidator());
        }
    }
}
