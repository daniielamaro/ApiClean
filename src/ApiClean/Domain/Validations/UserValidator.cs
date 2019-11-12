using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace ApiClean.Domain.Validations
{
    public class UserValidator : AbstractValidator<User.User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("O Id não pode ser nulo.")
                .NotEqual(new Guid())
                .WithMessage("O Id não pode ser vazio.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O Nome não pode estar em branco.")
                .Must(NameOnlyLetters)
                .WithMessage("O Nome não pode conter números ou caracteres especiais.")
                .MaximumLength(150)
                .WithMessage("O Nome não pode conter acima de 150 caracteres.");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O Email não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O Email não pode ficar em branco.")
                .EmailAddress()
                .WithMessage("O Email está em um formato inválido.");

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("A senha não pode ser nula.")
                .NotEmpty()
                .WithMessage("A senha não pode estar em branco.")
                .MinimumLength(8)
                .WithMessage("A senha precisa conter no mínimo 8 caracteres");
        }

        private bool NameOnlyLetters(string name)
        {
            return (name.All(c => Char.IsLetter(c) || c == ' '));
        }
    }
}
