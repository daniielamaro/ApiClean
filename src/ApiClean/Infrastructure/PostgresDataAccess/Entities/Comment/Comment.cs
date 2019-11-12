using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace ApiClean.Infrastructure.PostgresDataAccess.Entities.Comment
{
    public class Comment
    {
        public Guid Id { get; private set; }
        public User.User Autor { get; private set; }
        public string Content { get; private set; }

        [ForeignKey("PublicationId")]
        public Guid PublicationId { get; set; }

    }
}
