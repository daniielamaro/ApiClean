using Application.Boundaries.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Boundaries.Publication
{
    public interface IOutputPortPublication : IOutputPort<Domain.Publication.Publication>
    {
    }
}
