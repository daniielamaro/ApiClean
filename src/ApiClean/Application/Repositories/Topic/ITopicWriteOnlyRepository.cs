using Domain.Topic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApiClean.Application.Repositories
{
    public interface ITopicWriteOnlyRepository
    {
        int Save(Topic customer);

        int Add(Topic customer);

        int Add(List<Topic> customers);

        int Delete(Guid id);

        int Delete(Topic customer);

        int Update(Topic customer);
    }
}
