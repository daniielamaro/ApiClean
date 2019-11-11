﻿using ApiClean.Application.Repositories;
using Application.Boundaries.Publication;

namespace Application.UseCases.Publication.GetAll
{
    public class PublicationGetAllUseCase :  IPublicationGetAllUseCase
    {
        private readonly IPublicationReadOnlyRepository pubReadOnlyRepository;
        private readonly IOutputPortPublication output;

        public PublicationGetAllUseCase(IPublicationReadOnlyRepository pubReadOnlyRepository, IOutputPortPublication output)
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
