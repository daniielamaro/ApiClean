using ApiClean.Domain.Publication;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ApiClean.Application.Repositories
{
    public interface IPublicationReadOnlyRepository
    {
        Publication GetById(Guid id);

        IList<Publication> GetByFilter(Expression<Func<Publication, bool>> filter);

        IList<Publication> GetAll();
    }
}
