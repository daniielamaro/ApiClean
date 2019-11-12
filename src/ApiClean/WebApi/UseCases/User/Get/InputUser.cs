using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.UseCases.User.Get
{
    public class InputUser
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
