using ApiClean.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Publication.Save.Handler
{
    class SaveHandler : Handler<PublicationSaveRequest>
    {
        private readonly IPublicationWriteOnlyRepository pubReadOnlyRepository;

        public SaveHandler(IPublicationWriteOnlyRepository pubReadOnlyRepository)
        {
            this.pubReadOnlyRepository = pubReadOnlyRepository;
        }

        public override void ProcessRequest(PublicationSaveRequest request)
        {
            var ret = pubReadOnlyRepository.Save(request.Publication);
            if (ret == 0)
                throw new ArgumentException("Problem to save model");

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
