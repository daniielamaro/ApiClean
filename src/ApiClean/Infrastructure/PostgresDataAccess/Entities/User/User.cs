﻿using System;

namespace Infrastructure.PostgresDataAccess.Entities.Topic
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
