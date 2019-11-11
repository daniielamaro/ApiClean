using Application.UseCases.Repository.Handler;
using System;

namespace Application.UseCases.User.Save.Handlers
{
    public class ValidateHandler : Handler<UserSaveRequest>
    {
        public override void ProcessRequest(UserSaveRequest request)
        {
            if (!request.User.IsValid)
                throw new ArgumentException("Model invalid");

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
