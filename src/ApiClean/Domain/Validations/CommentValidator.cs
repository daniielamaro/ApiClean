using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Domain.Validations
{
    public class CommentValidator : AbstractValidator<Comment.Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("O Id não pode ser nulo.")
                .NotEqual(new Guid())
                .WithMessage("O comentario não pode estar vazio.");

            RuleFor(x => x.Autor)
                .SetValidator(new UserValidator());

            RuleFor(x => x.Content)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O comentario não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O comentario não pode estar vazio.");

            RuleFor(x => x.PublicationId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O Id da publicação não pode ser nulo.")
                .NotEqual(new Guid())
                .WithMessage("O Id da publicação não pode ser um Guid vazio (zerado)");
        }
     }   
}
