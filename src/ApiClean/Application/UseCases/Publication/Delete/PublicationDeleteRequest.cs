using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Publication.Delete
{
    public class PublicationDeleteRequest
    {
        public Guid PublicationId { get; private set; }

        public PublicationDeleteRequest(Guid publicationId)
        {
            PublicationId = publicationId;
        }
    }
}
