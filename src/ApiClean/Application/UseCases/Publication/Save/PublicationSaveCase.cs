using Application.Boundaries.User;
using Application.UseCases.Topic.Save.Handler;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Publication.Save
{
    class PublicationSaveCase
    {
        private readonly IOutputPort<Domain.Publication.Publication> output;
        private readonly ValidateHandler validateHandler;

        public PublicationSaveCase(IOutputPort<Domain.Publication.Publication> output, ValidateHandler validateHandler, SaveHandler saveHandler)
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
                output.Standard(request.Pub.Id);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
