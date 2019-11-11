using ApiClean.Application.Repositories;
using Application.Boundaries.Publication;
using Application.Boundaries.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Publication.Get
{
    public class PublicationGetUseCase
    {
        private readonly IOutputPortPublication output;
        private readonly IPublicationReadOnlyRepository pubReadOnlyRepository;

        public PublicationGetUseCase(IOutputPortPublication output, IPublicationReadOnlyRepository pubReadOnlyRepository)
        {
            this.output = output;
            this.pubReadOnlyRepository = pubReadOnlyRepository;
        }

        public void Execute(PublicationGetRequest request)
        {
            try
            {
                var pub = pubReadOnlyRepository.GetById(request.PubId);
                if (pub == null)
                {
                    output.NotFound($"Not found customer with id: {request.PubId}");
                    return;
                }
                output.Standard(pub);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
