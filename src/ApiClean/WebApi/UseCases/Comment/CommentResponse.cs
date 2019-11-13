using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClean.WebApi.UseCases.Comment
{
    public class CommentResponse
    {
        public Guid Id { get; private set; }
        public ApiClean.Domain.User.User User { get; private set; }
        public string Content { get; private set; }
        public CommentResponse(Guid id, ApiClean.Domain.User.User user, string content)
        {
            Id = id;
            User = user;
            Content = content;
        }
    }
}
