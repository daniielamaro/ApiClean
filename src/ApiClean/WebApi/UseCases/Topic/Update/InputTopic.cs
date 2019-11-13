using System.ComponentModel.DataAnnotations;
using System;

namespace WebApi.UseCases.Topic.Update
{
    public class InputTopic
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
