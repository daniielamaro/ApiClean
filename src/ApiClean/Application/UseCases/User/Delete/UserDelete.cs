using ApiClean.Application.Boundaries.User;
using ApiClean.Application.Repositories;
using System;

namespace ApiClean.Application.UseCases.User.Delete
{
    public class UserDelete : IUserDelete
    {
        private readonly IOutputPortUser output;
        private readonly IUserWriteOnlyRepository userWriteOnlyRepository;

        public UserDelete(IOutputPortUser output, IUserWriteOnlyRepository userWriteOnlyRepository)
        {
            this.output = output;
            this.userWriteOnlyRepository = userWriteOnlyRepository;
        }

        public void Execute(UserDeleteRequest request)
        {
            try
            {
                var alfa = userWriteOnlyRepository.Delete(request.UserId);
                if(alfa == 0)
                {
                    output.Standard(request.UserId);
                }
            }
            catch(Exception e)
            {
                output.Error($"Error on process: {e.Message}");
            }
        }
    }
}
