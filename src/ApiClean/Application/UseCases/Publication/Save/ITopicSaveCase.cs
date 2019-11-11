using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Publication.Save
{
    public interface ITopicSaveCase
    {
        void Execute(PublicationSaveRequest request);
    }
}
