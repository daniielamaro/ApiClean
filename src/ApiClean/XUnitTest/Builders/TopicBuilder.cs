using Domain.Topic;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTest.Builders
{
    public class TopicBuilder
    {
        public Guid Id;
        public string Name;

        public static TopicBuilder New()
        {
            var number = new Random().Next(1, 9999);

            return new TopicBuilder()
            {
                Id = Guid.NewGuid(),
                Name = "Tópico " + number.ToString()
            };
        }

        public TopicBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public TopicBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public Topic Build()
        {
            return new Topic(Id, Name);
        }
    }
}
