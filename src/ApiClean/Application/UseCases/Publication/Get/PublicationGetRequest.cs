using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Publication.Get
{
    public class PublicationGetRequest
    {
        public Guid PubId { get; private set; }

        public PublicationGetRequest(Guid pubId)
        {
            PubId = pubId;
        }
    }
}
