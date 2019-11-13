using System;
using System.ComponentModel.DataAnnotations;


namespace ApiClean.WebApi.UseCases.Topic.Delete
{
    public class InputTopic
    {
        [Required]
        public Guid TopicId { get; set; }
    }
}
