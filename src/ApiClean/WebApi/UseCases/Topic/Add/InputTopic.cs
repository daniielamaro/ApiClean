using System.ComponentModel.DataAnnotations;

namespace ApiClean.WebApi.UseCases.Topic.Add
{
    public class InputTopic
    {
        [Required]
        public string Name { get; set; }
    }
}
