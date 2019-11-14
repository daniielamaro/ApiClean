using Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Publication
{
    public class Publication : Entity
    {
        public User.User Autor { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime DateCreated { get; private set; }
        public List<Comment.Comment> Comments { get; private set; }
        public Topic.Topic Topic { get; private set; }

        public Publication(Guid id, User.User autor, string title, string content, DateTime dateCreated, List<Comment.Comment> comments, Topic.Topic topic)
        {
            Id = id;
            Autor = autor;
            Title = title;
            Content = content;
            DateCreated = dateCreated;
            Comments = comments;
            Topic = topic;

            Validate(this, new PublicationValidator());
        }

        public Publication()
        {

        }
    }
}
