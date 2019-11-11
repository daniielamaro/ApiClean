using ApiClean.Application.Repositories;
using Application.Boundaries.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Publication.Get
{
    public class PublicationGetUseCase
    {
        private readonly IOutputPort<Domain.Publication.Publication> output;
        private readonly IPublicationReadOnlyRepository pubReadOnlyRepository;

        public PublicationGetUseCase(IOutputPort<Domain.Publication.Publication> output, IPublicationReadOnlyRepository pubReadOnlyRepository)
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
