using ApiClean.Application.Boundaries.User;
using ApiClean.Application.Repositories;
using System;


namespace ApiClean.Application.UseCases.User.GetAll
{
    public class UserGetAllUseCase : IUserGetAllUseCase
    {
        private readonly IUserReadOnlyRepository userReadOnlyRepository;
        private readonly IOutputPortUser output;

        public UserGetAllUseCase(IUserReadOnlyRepository userReadOnlyRepository, IOutputPortUser output)
        {
            this.userReadOnlyRepository = userReadOnlyRepository;
            this.output = output;
        }

        public void Execute()
        {
            try
            {
                var user = userReadOnlyRepository.GetAll();
                output.Standard(user);
            }
            catch(Exception e)
            {
                output.Error($"Error on process: {e.Message}");
            }
        }
    }
}
