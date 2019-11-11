using Application.UseCases.Repository.Handler;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Comment.Save.Handlers
{
    public class ValidateHandler : Handler<CommentSaveRequest>
    {
        public override void ProcessRequest(CommentSaveRequest request)
        {
            if (!request.Comment.IsValid)
                throw new ArgumentException("Model invalid");

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
