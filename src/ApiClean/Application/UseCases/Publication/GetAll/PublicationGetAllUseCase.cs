using ApiClean.Application.Repositories
using Application.Boundaries.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Publication.GetAll
{
    public class PublicationGetAllUseCase :  IPublicationGetAllUseCase
    {
        private readonly IPublicationReadOnlyRepository pubReadOnlyRepository;
        private readonly IOutputPort<Domain.Publication.Publication> output;

        public PublicationGetAllUseCase(IPublicationReadOnlyRepository pubReadOnlyRepository, IOutputPort<Domain.Publication.Publication> output)
        {
            this.pubReadOnlyRepository = pubReadOnlyRepository;
            this.output = output;
        }

        public void Execute()
        {
            try
            {
                var pubs = pubReadOnlyRepository.GetAll();
                output.Standard(pubs);
            }
            catch (System.Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
