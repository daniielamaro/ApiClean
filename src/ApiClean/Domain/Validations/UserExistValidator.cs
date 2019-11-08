using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validations
{
    class UserExistValidator : AbstractValidator<User.User>
    {
        private readonly IUserRepository userRepository;

        public UserExistValidator()
        {
            userRepository = new UserRepository();

            RuleFor(x => x)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O id do user não pode ser nulo")
                .NotEmpty()
                .WithMessage("O id do user não pode ser vazio")
                .Must(VerifyUser)
                .WithMessage("Este usuario não existe.");
        }

        private bool VerifyUser(Guid id)
        {
            User user = userRepository.GetById(id);
            return (user != null);
        }
    }
}
