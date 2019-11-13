using ApiClean.Application.Boundaries.Publication;
using ApiClean.Application.Boundaries.User;
using ApiClean.Application.UseCases.Publication.Save.Handler;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.UseCases.Publication.Save
{
    public class PublicationSaveCase : IPublicationSaveCase
    {
        private readonly IOutputPortPublication output;
        private readonly ValidateHandler validateHandler;

        public PublicationSaveCase(IOutputPortPublication output, ValidateHandler validateHandler, SaveHandler saveHandler)
        {
            this.output = output;
            this.validateHandler = validateHandler;
            this.validateHandler.SetSucessor(saveHandler);
        }
        public void Execute(PublicationSaveRequest request)
        {
            try
            {
                validateHandler.ProcessRequest(request);
                output.Standard(request.Publication.Id);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
