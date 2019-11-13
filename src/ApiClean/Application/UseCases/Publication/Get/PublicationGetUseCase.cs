using ApiClean.Application.Repositories;
using Application.Boundaries.Publication;
using Application.Boundaries.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Publication.Get
{
    public class PublicationGetUseCase : IPublicationGetUseCase
    {
        private readonly IOutputPortPublication output;
        private readonly IPublicationReadOnlyRepository publicationReadOnlyRepository;

        public PublicationGetUseCase(IOutputPortPublication output, IPublicationReadOnlyRepository publicationReadOnlyRepository)
        {
            this.output = output;
            this.publicationReadOnlyRepository = publicationReadOnlyRepository;
        }

        public void Execute(PublicationGetRequest request)
        {
            try
            {
                var publication = publicationReadOnlyRepository.GetById(request.PublicationId);
                if (publication == null)
                {
                    output.NotFound($"Not found customer with id: {request.PublicationId}");
                    return;
                }
                output.Standard(publication);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
