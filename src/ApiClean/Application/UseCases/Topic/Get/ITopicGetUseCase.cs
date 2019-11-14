using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Topic.Get
{
    public interface ITopicGetUseCase
    {
        void Execute(TopicGetRequest request);
        Domain.Topic.Topic GetObject(TopicGetRequest request);
    }
}
