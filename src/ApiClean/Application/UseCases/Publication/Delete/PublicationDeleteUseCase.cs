﻿using ApiClean.Application.Repositories;
using ApiClean.Application.Boundaries.Publication;
using ApiClean.Application.Boundaries.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.UseCases.Publication.Delete
{
    public class PublicationDeleteUseCase : IPublicationDeleteUseCase
    {
        private readonly IOutputPortPublication output;
        private readonly IPublicationWriteOnlyRepository publicationWriteOnlyRepository;

        public PublicationDeleteUseCase(IOutputPortPublication output, IPublicationWriteOnlyRepository publicationWriteOnlyRepository)
        {
            this.output = output;
            this.publicationWriteOnlyRepository = publicationWriteOnlyRepository;
        }

        public void Execute(PublicationDeleteRequest request)
        {
            try
            {
                var ret = publicationWriteOnlyRepository.Delete(request.PubId);
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
