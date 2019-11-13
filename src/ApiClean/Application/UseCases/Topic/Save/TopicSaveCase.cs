using ApiClean.Application.Boundaries.Topic;
using ApiClean.Application.Boundaries.User;
using ApiClean.Application.UseCases.Topic.Save.Handler;
using ApiClean.Application.UseCases.Topic.Save.Handler.Handlers;
using ApiClean.Application.UseCases.Topic.Save.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.UseCases.Topic.Save
{
    public class TopicSaveCase : ITopicSaveCase
    {
        private readonly IOutputPortTopic output;
        private readonly ValidateHandler validateHandler;

        public TopicSaveCase(IOutputPortTopic output, ValidateHandler validateHandler, SaveHandler saveHandler)
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
