﻿using ApiClean.Application.Repositories;
using Application.Boundaries.User;
using System;

namespace Application.UseCases.User.Delete
{
    public class UserDeleteUseCase : IUserDeleteUseCase
    {
        private readonly IOutputPortUser output;
        private readonly IUserWriteOnlyRepository userWriteOnlyRepository;

        public UserDeleteUseCase(IOutputPortUser output, IUserWriteOnlyRepository userWriteOnlyRepository)
        {
            this.output = output;
            this.userWriteOnlyRepository = userWriteOnlyRepository;
        }

        public void Execute(UserDeleteRequest request)
        {
            try
            {
                var ret = userWriteOnlyRepository.Delete(request.UserId);

                if(ret == 0)
                {
                    output.Error($"Error on process Delete Topic");
                    return;
                }
                output.Standard(request.UserId);
            }
            catch(Exception e)
            {
                output.Error($"Error on process: {e.Message}");
            }
        }
    }
}
