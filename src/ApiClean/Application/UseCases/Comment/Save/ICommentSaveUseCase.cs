using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Comment.Save
{
    public interface ICommentSaveUseCase
    {
        void Execute(CommentSaveRequest request);
    }
}
