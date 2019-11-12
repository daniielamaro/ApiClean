using ApiClean.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApiClean.Application.Repositories
{
    public interface IUserWriteOnlyRepository
    {
        int Save(User user);

        int Add(User user);

        int Add(List<User> users);

        int Delete(Guid id);

        int Delete(User user);

        int Update(User user);
    }
}
