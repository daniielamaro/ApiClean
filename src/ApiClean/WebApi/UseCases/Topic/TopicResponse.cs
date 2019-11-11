using System;

namespace WebApi.UseCases.Topic
{
    public class TopicResponse
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public TopicResponse(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}