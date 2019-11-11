using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Comment;
using System.Text;

namespace ApiClean.Application.Repositories
{
    public interface ICommentWriteOnlyRepository
    {
        int Save(Comment customer);

        int Add(Comment customer);

        int Add(List<Comment> customers);

        int Delete(Guid id);

        int Delete(Comment customer);

        int Update(Comment customer);
    }
}
