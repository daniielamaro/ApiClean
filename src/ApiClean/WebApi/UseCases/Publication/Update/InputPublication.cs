using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.UseCases.Publication.Update
{
    public class InputPublication
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public Guid TopicId { get; set; }
    }
}
