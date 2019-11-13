﻿using ApiClean.Domain.Comment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClean.Infrastructure.PostgresDataAccess.Entities.Publication
{
    public class Publication
    {
        [Key]
        public Guid Id { get; private set; }
        [ForeignKey("AutorId")]
        public Guid AutorId { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime DateCreated { get; private set; }
        public List<Comment> Comments { get; private set; }
        [ForeignKey("TopicId")]
        public Guid TopicId { get; private set; }
    }
}