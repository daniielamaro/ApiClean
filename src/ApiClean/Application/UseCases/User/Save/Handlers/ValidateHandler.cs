using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.User.Save.Handlers
{
    public class ValidateHandler : Handler<UserSaveRequest>
    {
        public override void ProcessRequest(UserSaveRequest request)
        {
            if (!request.User.IsValid)
                throw new ArgumentException("Model invalid");

            if (Sucessor != null)
                Sucessor.ProcessRequest(request);
        }
    }
}
