using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.UseCases.Comment.Get
{
    public class InputComment
    {
        [Required]
        public Guid CommentId { get; set; }
    }
}
