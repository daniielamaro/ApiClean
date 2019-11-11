using Domain.Publication;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ApiClean.Application.Repositories
{
    public interface IPublicationWriteOnlyRepository
    {
        int Save(Publication customer);

        int Add(Publication customer);

        int Add(List<Publication> customers);

        int Delete(Guid id);

        int Delete(Publication customer);

        int Update(Publication customer);

    }
}
