using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.UseCases.Topic.Delete
{
     public interface ITopicDeleteUseCase
    {
        void Execute(TopicDeleteRequest request);
    }
}
