using ApiClean.Application.Repositories;
using AutoMapper;
using Domain.Publication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.PostgresDataAccess.Repositories
{
    public class PublicationRepository : IPublicationReadOnlyRepository, IPublicationWriteOnlyRepository
    {
        private readonly IMapper mapper;

        public PublicationRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(Publication publication)
        {
            var model = mapper.Map<Entities.Publication.Publication>(publication);
            using (Context context = new Context())
            {
                context.Publications.Add(model);
                context.SaveChanges();
            }
            return 1;
        }

        public int Add(List<Publication> publications)
        {
            var models = mapper.Map<List<Entities.Publication.Publication>>(publications);
            using (Context context = new Context())
            {
                context.Publications.AddRange(models);
                context.SaveChanges();
            }
            return 1;
        }

        public int Delete(Guid id)
        {
            using (var context = new Context())
            {
                var model = context.Publications.FirstOrDefault(u => u.Id == id);
                context.Publications.Remove(model);
                return context.SaveChanges();
            }
        }

        public int Delete(Publication publication)
        {
            using (var context = new Context())
            {
                var model = context.Publications.FirstOrDefault(u => u.Id == publication.Id);
                context.Publications.Remove(model);
                return context.SaveChanges();
            }
        }

        public IList<Publication> GetAll()
        {
            var list = new List<Publication>();
            using (var context = new Context())
            {
                list = mapper.Map<List<Publication>>(context.Publications.ToList());
            }
            return list;
        }

        public IList<Publication> GetByFilter(Expression<Func<Publication, bool>> filter)
        {
            using (var context = new Context())
            {
                return mapper.Map<List<Publication>>(context.Publications.Where(mapper.Map<Expression<Func<Entities.Publication.Publication, bool>>>(filter)).ToList());
            }
        }

        public Publication GetById(Guid id)
        {
            using (var context = new Context())
            {
                return mapper.Map<Publication>(context.Publications.FirstOrDefault(u => u.Id == id));
            }
        }

        public int Save(Publication publication)
        {
            if (GetById(publication.Id) == null)
                return Add(publication);
            else
                return Update(publication);
        }

        public int Update(Publication publication)
        {
            using (var context = new Context())
            {
                context.Entry(mapper.Map<Entities.Publication.Publication>(publication)).State = EntityState.Modified;
                return context.SaveChanges();
            }
        }
    }
}
