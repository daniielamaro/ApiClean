using Domain.Comment;
using System;
using System.Collections.Generic;


using System.ComponentModel.DataAnnotations;


namespace WebApi.UseCases.Publication.Add
{
    public class InputPublication
    {
        [Required]
        public Guid AutorId { get; private set; }
        [Required]
        public string Title { get; private set; }
        [Required]
        public string Content { get; private set; }
        [Required]
        public Guid TopicId { get; private set; }
    }
}
