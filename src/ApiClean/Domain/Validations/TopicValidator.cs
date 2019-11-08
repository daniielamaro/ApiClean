using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validations
{
    public class TopicValidator : AbstractValidator<Topic.Topic>
    {
        public TopicValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O Id não pode ser nulo.")
                .NotEqual(new Guid())
                .WithMessage("O Id não pode ser um Guid vazio");


            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O Nome não pode estar em branco.");
        }
    }
}
