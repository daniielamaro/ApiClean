using Application.UseCases.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Publication.Save.Handler
{
    class ValidateHandler : Handler<PublicationSaveRequest>
    {
        public override void ProcessRequest(PublicationSaveRequest request)
        {
            if (!request.Publication.IsValid)
                throw new ArgumentException("Model invalid");

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
