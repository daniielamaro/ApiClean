using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.UseCases.Publication.Delete
{
     public interface IPublicationDeleteUseCase
    {
        void Execute(PublicationDeleteRequest request);
    }
}
