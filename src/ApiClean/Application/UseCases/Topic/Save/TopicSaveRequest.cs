using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Topic.Save
{
    public class TopicSaveRequest
    {
        public Domain.Topic.Topic Topic{ get; private set; }

        public TopicSaveRequest(string name)
        {
            Topic = new Domain.Topic.Topic(Guid.NewGuid(), name);
        }

        public TopicSaveRequest(Guid id, string name)
        {
            Topic = new Domain.Topic.Topic(id, name);
        }
    }
}
