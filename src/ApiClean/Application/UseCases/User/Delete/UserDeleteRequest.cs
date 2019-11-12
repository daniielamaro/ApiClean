﻿using System;

namespace ApiClean.Application.UseCases.User.Delete
{
    public class UserDeleteRequest
    {
        public Guid UserId { get; private set; }

        public UserDeleteRequest(Guid userId)
        {
            UserId = userId;
        }
    }
}
