using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.UseCases.Comment.Save
{
    public interface ICommentSaveUseCase
    {
        void Execute(CommentSaveRequest request);
    }
}
