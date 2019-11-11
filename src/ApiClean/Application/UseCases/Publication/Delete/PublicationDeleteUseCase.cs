using ApiClean.Application.Repositories;
using Application.Boundaries.Publication;
using Application.Boundaries.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Publication.Delete
{
    public class PublicationDeleteUseCase : IPublicationDeleteUseCase
    {
        private readonly IOutputPortPublication output;
        private readonly IPublicationWriteOnlyRepository pubWriteOnlyRepository;

        public PublicationDeleteUseCase(IOutputPortPublication output, IPublicationWriteOnlyRepository pubWriteOnlyRepository)
        {
            this.output = output;
            this.pubWriteOnlyRepository = pubWriteOnlyRepository;
        }

        public void Execute(PublicationDeleteRequest request)
        {
            try
            {
                var ret = pubWriteOnlyRepository.Delete(request.PubId);
                if (ret == 0)
                {
                    output.Error($"Error on process Delete Publication");
                    return;
                }
                output.Standard(request.PubId);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
