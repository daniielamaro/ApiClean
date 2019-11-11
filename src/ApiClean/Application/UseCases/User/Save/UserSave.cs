using Application.Boundaries.User;
using Application.UseCases.User.Save.Handlers;
using Domain.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.User.Save
{
    class UserSave : IUserSave
    {
        private readonly IOutputPortUser output;
        private readonly ValidateHandler validateHandler;

        public UserSave(IOutputPortUser output, ValidateHandler validateHandler, SaveHandler saveHandler)
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
