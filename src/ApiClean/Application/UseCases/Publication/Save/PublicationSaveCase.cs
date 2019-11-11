using Application.Boundaries.Publication;
using Application.UseCases.Publication.Save.Handler;
using System;


namespace Application.UseCases.Publication.Save
{
    class PublicationSaveCase
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
