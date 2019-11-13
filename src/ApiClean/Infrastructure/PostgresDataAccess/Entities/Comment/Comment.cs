using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Infrastructure.PostgresDataAccess.Entities.Comment
{
    public class Comment
    {
        public Guid Id { get; private set; }
        [ForeignKey("AutorId")]
        public Guid AutorId { get; private set; }
        public string Content { get; private set; }
        [ForeignKey("PublicationId")]
        public Guid PublicationId { get; set; }

    }
}
