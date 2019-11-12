using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using ApiClean.Domain.Validations;

namespace ApiClean.Domain.User
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User(Guid id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;

            Validate(this, new UserValidator());
        }
    }
}
