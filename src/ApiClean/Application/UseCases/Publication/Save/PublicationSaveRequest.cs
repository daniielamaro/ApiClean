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


        public PublicationSaveRequest(Domain.User.User autor, string title, string content, Domain.Topic.Topic topic)
        {
            Publication = new Domain.Publication.Publication(
                Guid.NewGuid(), 
                autor, 
                title, 
                content, 
                DateTime.Now, 
                new List<Domain.Comment.Comment>(), 
                topic
            );
        }

        public PublicationSaveRequest(Guid id, Domain.User.User autor, string title, string content, Domain.Topic.Topic topic)
        {
            Publication = new Domain.Publication.Publication(
                id,
                autor,
                title,
                content,
                DateTime.Now,
                new List<Domain.Comment.Comment>(),
                topic
            );
        }

        
    }
}
