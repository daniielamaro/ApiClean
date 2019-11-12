using ApiClean.Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApiClean.Domain.Comment
{
   public class Comment : Entity
   {
        public User.User Autor { get; private set; }
        public string Content { get; private set; }

        [ForeignKey("PublicationId")]
        public Guid PublicationId { get; set; }
        
        public Comment(Guid id, User.User autor, string content, Guid publicationId)
        {
            Id = id;
            Autor = autor;
            Content = content;
            PublicationId = publicationId;

            Validate(this, new CommentValidator());
        }
   }
}
