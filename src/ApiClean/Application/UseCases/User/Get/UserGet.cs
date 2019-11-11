using ApiClean.Application.Repositories;
using System;

namespace Application.UseCases.User.Get
{
    public class UserGet
    {
        private readonly IUserReadOnlyRepository userReadOnlyRepository;
        private readonly IOutputPortUser output;

        public UserGet(IOutputPortUser output, IUserReadOnlyRepository userReadOnlyRepository)
        {
            this.output = output;
            this.userReadOnlyRepository = userReadOnlyRepository;
        }

        public void Execute(UserGetRequest request)
        {
            try
            {
                var user = userReadOnlyRepository.GetById(request.UserId);
                if(user == null)
                {
                    output.NotFound($"User not found with id: {request.UserId}");
                    return;
                }
                output.Standard(user);
            }
            catch(Exception e)
            {
                output.Error($"Error on process: {e.Message}");
            }
        }
    }
}
