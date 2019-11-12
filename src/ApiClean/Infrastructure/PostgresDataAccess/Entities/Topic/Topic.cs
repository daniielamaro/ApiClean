using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Infrastructure.PostgresDataAccess.Entities.Topic
{
    public class Topic
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

    }
}
