using ApiClean.Application.Boundaries.User;
using ApiClean.Application.UseCases.User.Save.Handlers;
using System;

namespace ApiClean.Application.UseCases.User.Save
{
    class UserSaveUseCase : IUserSaveUseCase
    {
        private readonly IOutputPortUser output;
        private readonly ValidateHandler validateHandler;

        public UserSaveUseCase(IOutputPortUser output, ValidateHandler validateHandler, SaveHandler saveHandler)
        {
            this.output = output;
            this.validateHandler = validateHandler;
            this.validateHandler.SetSucessor(saveHandler);
        }

        public void Execute(UserSaveRequest request)
        {
            try
            {
                validateHandler.ProcessRequest(request);
                output.Standard(request.User.Id);
            }
            catch(Exception e)
            {
                output.Error("Error on process: ");
                Console.Write(e.Message);
            }
        }
    }
}
