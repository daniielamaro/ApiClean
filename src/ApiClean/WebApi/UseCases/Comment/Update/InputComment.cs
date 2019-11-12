using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.UseCases.Comment.Update
{
    public class InputComment
    {
        [Required]
        public Guid CommentId { get; set; }
        [Required]
        public Domain.User.User Autor { get; set; }
        [Required]
        public string Content { get; private set; }
        [Required]
        public Guid PublicationId { get; set; }
    }
}
