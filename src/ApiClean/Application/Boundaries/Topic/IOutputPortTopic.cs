using Application.Boundaries.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.Boundaries.Topic
{
    public interface IOutputPortTopic : IOutputPort<Domain.Topic.Topic>
    {
    }
}
