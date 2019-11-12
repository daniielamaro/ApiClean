using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Publication.Get
{
    public class PublicationGetRequest
    {
        public Guid PublicationId { get; private set; }

        public PublicationGetRequest(Guid publicationId)
        {
            PublicationId = publicationId;
        }
    }
}
