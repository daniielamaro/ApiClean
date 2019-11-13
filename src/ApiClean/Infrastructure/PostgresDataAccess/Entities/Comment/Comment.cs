using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Infrastructure.PostgresDataAccess.Entities.Comment
{
    public class Comment
    {
        public Guid Id { get; private set; }
        public User.User Autor { get; private set; }
        public string Content { get; private set; }
        public Guid PublicationId { get; set; }

    }
}
