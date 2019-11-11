using Domain.Comment;
using Domain.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Publication.Save
{
    public class PublicationSaveRequest
    {
        public Domain.Publication.Publication Publication { get; private set; }


        public PublicationSaveRequest(User autor, string title, string content, DateTime dateCreated, List<Comment> comment, Domain.Topic.Topic topic)
        {
            Publication = new Domain.Publication.Publication(Guid.NewGuid(), autor, title, content, dateCreated, comment, topic);

        }

        public PublicationSaveRequest(Guid id, User autor, string title, string content, DateTime dateCreated, List<Comment> comment, Domain.Topic.Topic topic)
        {
            Publication = new Domain.Publication.Publication(id, autor, title, content, dateCreated, comment, topic);
        }
    }
}
