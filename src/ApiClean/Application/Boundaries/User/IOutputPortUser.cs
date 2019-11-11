using Application.Boundaries.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Boundaries.User
{
    public interface IOutputPortUser : IOutputPort<Domain.User.User>
    {
    }
}
