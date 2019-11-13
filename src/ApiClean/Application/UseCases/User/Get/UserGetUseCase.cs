
using ApiClean.Application.Repositories;
using Application.Boundaries.User;
using System;

namespace Application.UseCases.User.Get
{
    public class UserGetUseCase : IUserGetUseCase
    {
        private readonly IOutputPortUser output;
        private readonly IUserReadOnlyRepository userReadOnlyRepository;

        public UserGetUseCase(IOutputPortUser output, IUserReadOnlyRepository userReadOnlyRepository)
        {
            this.output = output;
            this.userReadOnlyRepository = userReadOnlyRepository;
        }

        public void Execute(UserGetRequest request)
        {
            try
            {
                var user = userReadOnlyRepository.GetById(request.UserId);
                if (user == null)
                {
                    output.NotFound($"Not found user with id: {request.UserId}");
                    return;
                }
                output.Standard(user);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
