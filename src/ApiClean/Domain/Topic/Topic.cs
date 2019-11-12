using Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Domain.Topic
{
    public class Topic : Entity
    {
        public string Name { get; private set; }

        public Topic(Guid id, string name)
        {
            Id = id;
            Name = name;

            Validate(this, new TopicValidator());
        }
    }
}
