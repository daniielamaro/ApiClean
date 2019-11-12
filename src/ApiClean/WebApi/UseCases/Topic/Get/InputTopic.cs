using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.UseCases.Topic.Get
{
    public class InputTopic
    {
        [Required]
        public Guid TopicId { get; set; }
    }
}