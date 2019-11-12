using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.UseCases.Publication.Delete
{
    public class PublicationDeleteRequest
    {
        public Guid PubId { get; private set; }

        public PublicationDeleteRequest(Guid pubId)
        {
            PubId = pubId;
        }
    }
}
