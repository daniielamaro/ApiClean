using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Domain
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
