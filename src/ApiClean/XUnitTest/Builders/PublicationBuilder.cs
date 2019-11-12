using Domain.Comment;
using Domain.Publication;
using Domain.Topic;
using Domain.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Tests.XUnitTest.Builders
{
    public class PublicationBuilder
    {
        public Guid Id;
        public User Autor;
        public string Title;
        public string Content;
        public DateTime DateCreated;
        public List<Comment> Comments;
        public Topic Topic;

        public static PublicationBuilder New()
        {
            var user = UserBuilder.New().Build();

            var topic = TopicBuilder.New().Build();

            return new PublicationBuilder()
            {
                Id = Guid.NewGuid(),
                Autor = user,
                Title = "Titulo Publicação",
                Content = "Conteudo Publicação",
                DateCreated = DateTime.Now,
                Comments = new List<Comment>(),
                Topic = topic
            };
        }

        public PublicationBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public PublicationBuilder WithAutor(User user)
        {
            Autor = user;
            return this;
        }

        public PublicationBuilder WithTitle(string title)
        {
            Title = title;
            return this;
        }

        public PublicationBuilder WithContent(string content)
        {
            Content = content;
            return this;
        }

        public PublicationBuilder WithDate(DateTime date)
        {
            DateCreated = date;
            return this;
        }

        public PublicationBuilder WithComments(List<Comment> comments)
        {
            Comments = comments;
            return this;
        }

        public PublicationBuilder WithTopic(Topic topic)
        {
            Topic = topic;
            return this;
        }

        public Publication Build()
        {
            return new Publication(Id, Autor, Title, Content, DateCreated, Comments, Topic);
        }
    }
}
