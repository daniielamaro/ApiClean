using System.ComponentModel.DataAnnotations;

namespace WebApi.UseCases.Topic.Update
{
    public class InputTopic
    {
        [Required]
        public string Name { get; set; }
    }
}
