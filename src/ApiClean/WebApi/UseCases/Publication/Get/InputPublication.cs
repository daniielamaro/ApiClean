using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.UseCases.Publication.Get
{
    public class InputPublication
    {
        [Required]
        public Guid PublicationId { get; private set; }
    }
}
