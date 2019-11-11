using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Topic.Save.Handler
{
    class ValidateHandler : Handler<TopicSaveRequest>
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
