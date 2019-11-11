using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Comment.Delete
{
    public class CommentDeleteRequest
    {
        public Guid CommentId { get; private set; }

        public CommentDeleteRequest(Guid commentId)
        {
            CommentId = commentId;
        }
    }
}
