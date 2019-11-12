using ApiClean.Application.Repositories;
using AutoMapper;
using Domain.Publication;
using System;
using System.Collections.Generic;
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

        public int Delete(User user)
        {
            using (var context = new Context())
            {
                var model = context.Users.FirstOrDefault(u => u.Id == user.Id);
                context.Users.Remove(model);
                return context.SaveChanges();
            }
        }

        public IList<User> GetAll()
        {
            var list = new List<User>();
            using (var context = new Context())
            {
                list = mapper.Map<List<User>>(context.Users.ToList());
            }
            return list;
        }

        public IList<User> GetByFilter(Expression<Func<User, bool>> filter)
        {
            using (var context = new Context())
            {
                return mapper.Map<List<User>>(context.Users.Where(mapper.Map<Expression<Func<Entities.User.User, bool>>>(filter)).ToList());
            }
        }

        public User GetById(Guid id)
        {
            using (var context = new Context())
            {
                return mapper.Map<User>(context.Users.FirstOrDefault(u => u.Id == id));
            }
        }

        public int Save(User user)
        {
            if (GetById(user.Id) == null)
                return Add(user);
            else
                return Update(user);
        }

        public int Update(User user)
        {
            using (var context = new Context())
            {
                context.Entry(mapper.Map<Entities.User.User>(user)).State = EntityState.Modified;
                return context.SaveChanges();
            }
        }
    }
}
