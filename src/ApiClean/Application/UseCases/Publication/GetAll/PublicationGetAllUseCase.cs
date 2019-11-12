using ApiClean.Application.Repositories;
using Application.Boundaries.Publication;
using Application.Boundaries.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.UseCases.Publication.GetAll
{
    public class PublicationGetAllUseCase :  IPublicationGetAllUseCase
    {
        private readonly IPublicationReadOnlyRepository publicationReadOnlyRepository;
        private readonly IOutputPortPublication output;

        public PublicationGetAllUseCase(IPublicationReadOnlyRepository publicationReadOnlyRepository, IOutputPortPublication output)
        {
            this.publicationReadOnlyRepository = publicationReadOnlyRepository;
            this.output = output;
        }

        public void Execute()
        {
            try
            {
                var publications = publicationReadOnlyRepository.GetAll();
                output.Standard(publications);
            }
            catch (System.Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
