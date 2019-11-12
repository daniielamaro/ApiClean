using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.UseCases.Comment
{
    public class CommentResponse
    {
        public Guid Id { get; private set; }
        public Domain.User.User User { get; private set; }
        public string Content { get; private set; }
        public Guid PublicationId { get; private set; }

        public CommentResponse(Guid id, Domain.User.User user, string content, Guid publicationId)
        {
            Id = id;
            User = user;
            Content = content;
            PublicationId = publicationId;
        }
    }
}
