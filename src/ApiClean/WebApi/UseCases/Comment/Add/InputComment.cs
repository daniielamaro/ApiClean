using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.UseCases.Comment.Add
{
    public class InputComment
    {
        [Required]
        public Domain.User.User user { get; set; }

        [Required]
        public string content { get; set; }
    }
}
