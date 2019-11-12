using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.UseCases.Topic.Get
{
    public interface ITopicGetUseCase
    {
        void Execute(TopicGetRequest request);

    }
}
