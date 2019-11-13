using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.PostgresDataAccess.Entities.Publication
{
    public class Publication
    {
        public Guid Id { get; private set; }
        public User.User Autor { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime DateCreated { get; private set; }
        public List<Comment.Comment> Comments { get; private set; }
        public Topic.Topic Topic { get; private set; }
    }
}
