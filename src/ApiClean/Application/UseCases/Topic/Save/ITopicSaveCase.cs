using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Topic.Save
{
    public interface ITopicSaveCase
    {
        void Execute(TopicSaveRequest request);
    }
}
