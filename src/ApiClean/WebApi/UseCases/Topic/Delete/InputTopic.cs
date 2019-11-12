using System;
using System.ComponentModel.DataAnnotations;


namespace WebApi.UseCases.Topic.Delete
{
    public class InputTopic
    {
        [Required]
        public Guid TopicId { get; set; }
    }
}
