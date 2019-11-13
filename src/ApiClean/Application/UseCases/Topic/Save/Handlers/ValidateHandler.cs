using ApiClean.Application.UseCases.Repository.Handler;
using System;

namespace ApiClean.Application.UseCases.Topic.Save.Handler.Handlers
{
    public class ValidateHandler : Handler<TopicSaveRequest>
    {
        public override void ProcessRequest(TopicSaveRequest request)
        {
            if (!request.Topic.IsValid)
                throw new ArgumentException("Model invalid");

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
