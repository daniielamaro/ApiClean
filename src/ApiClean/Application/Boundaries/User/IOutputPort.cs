using System;
using System.Collections.Generic;

namespace Application.Boundaries.User
{
    public interface IOutputPort
    {
        void Standard(Guid id);

        void Standard(Domain.User.User user);

        void Standard(IList<Domain.User.User> user);

        void NotFound(string message);

        void Error(string message);
    }
}
