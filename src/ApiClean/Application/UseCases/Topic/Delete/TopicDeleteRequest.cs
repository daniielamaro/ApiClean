using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.UseCases.Topic.Delete
{
    public class TopicDeleteRequest
    {
        public Guid TopicId { get; private set; }

        public TopicDeleteRequest(Guid topicId)
        {
            TopicId = topicId;
        }
    }
}
