using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validations
{
    public class TopicValidator : AbstractValidator<Topic.Topic>
    {
        private readonly ITopicRepository topicRepository;

        public TopicValidator()
        {
            topicRepository = new TopicRepository();

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
                .WithMessage("O Nome não pode estar em branco.")
                .Must((topic, name) => NameNotExists(topic, name))
                .WithMessage("Este nome de tópico já existe na base de dados.");
        }

        private bool NameNotExists(Topic topic, string name)
        {
            List<Topic> topics = topicRepository.GetAll();

            return !(topics.Exists(x => x.Name == name && x.Id != topic.Id));
        }
    }
}
