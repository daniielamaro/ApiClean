using System;
using System.ComponentModel.DataAnnotations;
using Domain.Comment;

namespace WebApi.UseCases.Publication.Update
{
    public class InputPublication
    {
        [Required]
        public Guid Id { get; private set; }
        [Required]
        public Domain.User.User Autor { get; private set; }
        [Required]
        public string Title { get; private set; }
        [Required]
        public string Content { get; private set; }
        [Required]
        public DateTime DateCreated { get; private set; }
        [Required]
        public List<Comment> Comments { get; private set; }
        [Required]
        public Domain.Topic.Topic Topic { get; private set; }
    }
}
