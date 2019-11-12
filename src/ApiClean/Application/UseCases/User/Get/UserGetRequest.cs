﻿using System;

namespace ApiClean.Application.UseCases.User.Get
{
    public class UserGetRequest
    {
        public Guid UserId { get; private set; }

        public UserGetRequest(Guid userId)
        {
            UserId = userId;
        }
    }
}
