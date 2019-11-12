using System;
using System.ComponentModel.DataAnnotations;


namespace WebApi.UseCases.Topic.Save
{
    public class InputTopic
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
