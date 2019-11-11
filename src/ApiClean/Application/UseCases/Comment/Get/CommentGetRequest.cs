using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Comment.Get
{
    public class CommentGetRequest
    {
        public Guid CommentId { get; private set; }

        public CommentGetRequest(Guid commentId)
        {
            CommentId = commentId;
        }
    }
}
