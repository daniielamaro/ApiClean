using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation.Results;
using FluentValidation;

namespace Domain
{
    public class Entity : IEntity
    {
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
