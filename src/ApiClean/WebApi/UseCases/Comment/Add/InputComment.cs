using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.UseCases.Comment.Add
{
    public class InputComment
    {
        [Required]
        public Domain.User.User User { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public Guid PublicationId { get; set; }
    }
}
