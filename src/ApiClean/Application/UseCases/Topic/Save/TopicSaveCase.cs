using Application.Boundaries.User;
using Application.UseCases.Topic.Save.Handler;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Topic.Save
{
    class TopicSaveCase
    {
        private readonly IOutputPort<Domain.Topic.Topic> output;
        private readonly ValidateHandler validateHandler;

        public TopicSaveCase(IOutputPort<Domain.Topic.Topic> output, ValidateHandler validateHandler, SaveHandler saveHandler)
        {
            this.output = output;
            this.validateHandler = validateHandler;
            this.validateHandler.SetSucessor(saveHandler);
        }
        public void Execute(TopicSaveRequest request)
        {
            try
            {
                validateHandler.ProcessRequest(request);
                output.Standard(request.Topic.Id);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
