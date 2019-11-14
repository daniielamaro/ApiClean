using Application.Boundaries.User;
using Application.UseCases.User.Save.Handlers;
using System;

namespace Application.UseCases.User.Save
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
                output.Standard(request.User);
            }
            catch(Exception e)
            {
                output.Error("Error on process: ");
                Console.Write(e.Message);
            }
        }
    }
}
