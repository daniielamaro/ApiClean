using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.UseCases.Topic.Save
{
    public interface ITopicSaveCase
    {
        void Execute(TopicSaveRequest request);
    }
}
