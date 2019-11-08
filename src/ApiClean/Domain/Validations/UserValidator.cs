using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Domain.Validations
{
    public class UserValidator : AbstractValidator<User.User>
    {
        private readonly IUserRepository userRepository;

        public UserValidator()
        {
            userRepository = new UserRepository();

            RuleFor(x => x.Id)
                .NotNull()
                .NotEqual(new Guid())
                .WithMessage("O Id não pode ser nulo.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O Nome não pode estar em branco.")
                .Must(NameOnlyLetters)
                .WithMessage("O Nome não pode conter números ou caracteres especiais.")
                .MaximumLength(150);

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O Email não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O Email não pode ficar em branco.")
                .EmailAddress()
                .WithMessage("O Email está em um formato inválido.")
                .Must((user, email) => EmailNotExists(user, email))
                .WithMessage("Este Email já está registrado na base de dados")
                .MaximumLenght(150);

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

        private bool EmailNotExists(User user, string email)
        {
            List<User> listUsers = userRepository.GetAll();

            return !(listUsers.Exists(x => x.Email == email && x.Id != user.Id));
        }
    }
}
