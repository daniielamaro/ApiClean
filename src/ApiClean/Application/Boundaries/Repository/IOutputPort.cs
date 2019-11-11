using System;
using System.Collections.Generic;

namespace Application.Boundaries.Repository
{
    public interface IOutputPort<T>
    {
        void Standard(Guid id);

        void Standard(T model);

        void Standard(IList<T> model);

        void NotFound(string message);

        void Error(string message);
    }
}
