using Domain.Publication;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ApiClean.Application.Repositories
{
    public interface IPublicationWriteOnlyRepository
    {
        int Save(Publication publication);

        int Add(Publication publication);

        int Add(List<Publication> publications);

        int Delete(Guid id);

        int Delete(Publication publication);

        int Update(Publication publication);

    }
}
