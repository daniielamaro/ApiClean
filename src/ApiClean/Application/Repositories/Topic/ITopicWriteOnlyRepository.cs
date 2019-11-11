using Domain.Topic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApiClean.Application.Repositories
{
    public interface ITopicWriteOnlyRepository
    {
        int Save(Topic topic);

        int Add(Topic topic);

        int Add(List<Topic> topic);

        int Delete(Guid id);

        int Delete(Topic topic);

        int Update(Topic topic);
    }
}
