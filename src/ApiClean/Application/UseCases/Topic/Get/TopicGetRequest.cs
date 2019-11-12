using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Topic.Get
{
    public class TopicGetRequest
    {
        public Guid TopicId{ get; private set; }

        public TopicGetRequest(Guid topicId)
        {
            TopicId = topicId;
        }
    }
}
