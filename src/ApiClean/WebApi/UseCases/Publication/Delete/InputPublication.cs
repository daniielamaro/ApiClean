using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.UseCases.Publication.Delete
{
    public class InputPublication
    {
        [Required]
        public Guid PublicationId { get; set; }
    }
}
