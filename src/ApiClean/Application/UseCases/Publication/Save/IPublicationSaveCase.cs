using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.UseCases.Publication.Save
{
    public interface IPublicationSaveCase
    {
        void Execute(PublicationSaveRequest request);
    }
}
