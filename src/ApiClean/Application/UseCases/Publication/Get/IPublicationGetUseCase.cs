using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.UseCases.Publication.Get
{
    public interface IPublicationGetUseCase
    {
        void Execute(PublicationGetRequest request);

    }
}
