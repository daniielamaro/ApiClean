﻿using Domain.Comment;
using System;
using System.Collections.Generic;


using System.ComponentModel.DataAnnotations;


namespace WebApi.UseCases.Publication.Add
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
        public List<Domain.Comment.Comment> Comments { get; private set; }
        [Required]
        public Domain.Topic.Topic Topic { get; private set; }
    }
}