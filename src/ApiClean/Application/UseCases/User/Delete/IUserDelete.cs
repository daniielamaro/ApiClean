﻿namespace Application.UseCases.User.Delete
{
    public interface IUserDelete
    {
        void Execute(UserDeleteRequest request);
    }
}