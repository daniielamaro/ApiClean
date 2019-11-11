using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Publication.Get
{
    public interface IPublicationGetUseCase
    {
        void Execute(PublicationGetRequest request);

    }
}
