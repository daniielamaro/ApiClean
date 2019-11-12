using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApiClean.Domain.Comment;
using System.Text;

namespace ApiClean.Application.Repositories
{
    public interface ICommentWriteOnlyRepository
    {
        int Save(Comment comment);

        int Add(Comment comment);

        int Add(List<Comment> comments);

        int Delete(Guid id);

        int Delete(Comment comment);

        int Update(Comment comment);
    }
}
