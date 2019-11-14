using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.UseCases.Publication.Add
{
    public class InputPublication
    {
        [Required]
        public Guid AutorId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public Guid TopicId { get; set; }
    }
}
