using Application.Boundaries.Repository;
using Application.Boundaries.User;
using Application.UseCases.User.Save.Handlers;
using System;

namespace Application.UseCases.User.Save
{
    class UserSave : IUserSave
    {
        private readonly IOutputPort<Domain.User.User> output;
        private readonly ValidateHandler validateHandler;

        public UserSave(IOutputPort<Domain.User.User> output, ValidateHandler validateHandler, SaveHandler saveHandler)
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
