﻿using Domain.Comment;
using Domain.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Publication.Save
{
    public class PublicationSaveRequest
    {
        public Domain.Publication.Publication Publication { get; private set; }


        public PublicationSaveRequest(Domain.User.User autor, string title, string content, DateTime dateCreated, List<Domain.Comment.Comment> comment, Domain.Topic.Topic topic)
        {
            Publication = new Domain.Publication.Publication(Guid.NewGuid(), autor, title, content, dateCreated, comment, topic);

        }

        public PublicationSaveRequest(Guid id, Domain.User.User autor, string title, string content, DateTime dateCreated, List<Domain.Comment.Comment> comment, Domain.Topic.Topic topic)
        {
            Publication = new Domain.Publication.Publication(id, autor, title, content, dateCreated, comment, topic);
        }
    }
}