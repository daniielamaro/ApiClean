using System;
using FluentValidation.Results;
using FluentValidation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Entity : IEntity
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid Id { get; set; }

        [NotMapped]
        public bool IsValid { get; private set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }

        public bool Validate<TEntity>(TEntity model, AbstractValidator<TEntity> validator)
        {
            ValidationResult = validator.Validate(model);
            return IsValid = ValidationResult.IsValid;
        }
    }
}
