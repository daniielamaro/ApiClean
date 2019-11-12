using System;
using System.Collections.Generic;

namespace Application.UseCases.Comment.Save
{
    public class CommentSaveRequest
    {
        public Domain.Comment.Comment Comment { get; private set; }

        public CommentSaveRequest(Domain.User.User author, string content, Guid publicationId)
        {
            Comment = new Domain.Comment.Comment(Guid.NewGuid(), author, content, publicationId);
        }

        public CommentSaveRequest(Guid id, Domain.User.User author, string content, Guid publicationId)
        {
            Comment = new Domain.Comment.Comment(id, author, content, publicationId);
        }
    }
}
