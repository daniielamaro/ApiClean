using Domain.Comment;
using System;
using System.Collections.Generic;

namespace WebApi.UseCases.Publication
{
    public class PublicationResponse
    {

        public Guid Id { get; private set; }
        public Domain.User.User Autor { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime DateCreated { get; private set; }
        public List<Domain.Comment.Comment> Comments { get; private set; }
        public Domain.Topic.Topic Topic { get; private set; }

        public PublicationResponse(Guid id, Domain.User.User autor, string title, string content, DateTime dateCreated, List<Domain.Comment.Comment> comments, Domain.Topic.Topic topic)
        {
            Id = id;
            Autor = autor;
            Title = title;
            Content = content;
            DateCreated = dateCreated;
            Comments = comments;
            Topic = topic;
        }
    }
}