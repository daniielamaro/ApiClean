using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.UseCases.Comment.Get
{
    public interface ICommentGetUseCase
    {
        void Execute(CommentGetRequest request);
    }
}
