using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApiClean.Application.Repositories
{
    public interface IUserWriteOnlyRepository
    {
        int Save(User customer);

        int Add(User customer);

        int Add(List<User> customers);

        int Delete(Guid id);

        int Delete(User customer);

        int Update(User customer);
    }
}
