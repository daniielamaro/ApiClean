using ApiClean.Application.Boundaries.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.Boundaries.User
{
    public interface IOutputPortUser : IOutputPort<ApiClean.Domain.User.User>
    {
    }
}
