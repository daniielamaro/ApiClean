using ApiClean.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.User.Save.Handlers
{
    public class SaveHandler : Handler<UserSaveRequest>
    {
        private readonly IUserWriteOnlyRepository userWriteOnlyRepository;

        public SaveHandler(IUserWriteOnlyRepository userWriteOnly)
        {
            userWriteOnlyRepository = userWriteOnly;
        }

        public override void ProcessRequest(UserSaveRequest request)
        {
            var ret = userWriteOnlyRepository.Save(request.User);
            if (ret == 0)
                throw new ArgumentException("Problema ao salvar!");

            if (Sucessor != null)
                Sucessor.ProcessRequest(request);
        }
    }
}
