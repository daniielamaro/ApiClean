using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.UseCases.User.Add
{
    public class InputUser
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
