using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApiClean.Application.Repositories
{
    public interface IUserReadOnlyRepository
    {
        User GetById(Guid id);

        IList<User> GetByFilter(Expression<Func<User, bool>> filter);

        IList<User> GetAll();

    }
}
