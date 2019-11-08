﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validations
{
    public class TopicExistValidator : AbstractValidator<Guid>
    {
        private readonly ITopicRepository topicRepository;
        public TopicExistValidator()
        {
            topicRepository = new TopicRepository();

            RuleFor(x => x)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O id do tópico não pode ser nulo")
                .NotEmpty()
                .WithMessage("O id do tópico não pode ser vazio")
                .Must(VerifyTopic)
                .WithMessage("Este tópico não existe.");
        }

        private bool VerifyTopic(Guid id)
        {
            Topic topic = topicRepository.GetById(id);
            return (topic != null);
        }
    }
}
