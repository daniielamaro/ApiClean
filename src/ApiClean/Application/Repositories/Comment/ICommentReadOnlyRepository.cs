using System;
using System.Collections.Generic;
using Domain.Comment;
using System.Text;
using System.Linq.Expressions;

namespace ApiClean.Application.Repositories
{
    public interface ICommentReadOnlyRepository
    {
        Comment GetById(Guid id);

        IList<Comment> GetByFilter(Expression<Func<Comment, bool>> filter);

        IList<Comment> GetAll();
    }
}
