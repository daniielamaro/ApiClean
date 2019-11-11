using Application.UseCases.User.Save.Handlers;
using System;

namespace Application.UseCases.Topic.Save.Handler
{
    public class ValidateHandler : Handler<TopicSaveRequest>
    {
        public override void ProcessRequest(TopicSaveRequest request)
        {
            if (!request.Topic.IsValid)
                throw new ArgumentException("Model invalid");

            if (Sucessor != null)
                Sucessor.ProcessRequest(request);
        }
    }
}
