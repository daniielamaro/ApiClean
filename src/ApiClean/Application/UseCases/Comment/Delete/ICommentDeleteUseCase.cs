using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.UseCases.Comment.Delete
{
    public interface ICommentDeleteUseCase
    {
        void Execute(CommentDeleteRequest request);
    }
}
