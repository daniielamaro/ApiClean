using ApiClean.Application.Repositories;
using Application.UseCases.Repository.Handler;
using System;

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

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
