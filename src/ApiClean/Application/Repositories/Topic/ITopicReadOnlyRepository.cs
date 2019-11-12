using ApiClean.Domain.Topic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApiClean.Application.Repositories
{
    public interface ITopicReadOnlyRepository
    {
        Topic GetById(Guid id);

        IList<Topic> GetByFilter(Expression<Func<Topic, bool>> filter);

        IList<Topic> GetAll();
    }
}
