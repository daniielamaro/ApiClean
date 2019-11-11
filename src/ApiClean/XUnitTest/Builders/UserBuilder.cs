using Domain.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTest.Builders
{
    public class UserBuilder
    {
        public Guid Id;
        public string Name;
        public string Email;
        public string Password;

        public static UserBuilder New()
        {
            var number = new Random().Next(1, 9999);

            return new UserBuilder()
            {
                Id = Guid.NewGuid(),
                Name = "Humano Legal",
                Email = "humano" + number.ToString() + "@email.com",
                Password = "1234567890"
            };
        }

        public UserBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public UserBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public UserBuilder WithEmail(string email)
        {
            Email = email;
            return this;
        }

        public UserBuilder WithPassword(string password)
        {
            Password = password;
            return this;
        }

        public User Build()
        {
            return new User(Id, Name, Email, Password);
        }
    }
}
