using ApiClean.Domain.Comment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiClean.WebApi.UseCases.Publication.Update
{
    public class InputPublication
    {
        [Required]
        public Guid Id { get; private set; }
        [Required]
        public ApiClean.Domain.User.User Autor { get; private set; }
        [Required]
        public string Title { get; private set; }
        [Required]
        public string Content { get; private set; }
        [Required]
        public DateTime DateCreated { get; private set; }
        [Required]
        public List<Comment> Comments { get; private set; }
        [Required]
        public ApiClean.Domain.Topic.Topic Topic { get; private set; }
    }
}
