using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.UseCases.User.Delete
{
    public class InputUser
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
