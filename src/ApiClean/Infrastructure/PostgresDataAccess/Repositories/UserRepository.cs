using System;
using System.Collections.Generic;
using AutoMapper;
using ApiClean.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Domain.User;

namespace ApiClean.Infrastructure.PostgresDataAccess.Repositories
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        private readonly IMapper mapper;

        public UserRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(User user)
        {
            var model = mapper.Map<Entities.User.User>(user);
            using (Context context = new Context())
            {
                context.Users.Add(model);
                context.SaveChanges();
            }
            return 1;
        }

        public int Add(List<User> users)
        {
            var models = mapper.Map<List<Entities.User.User>>(users);
            using (Context context = new Context())
            {
                context.Users.AddRange(models);
                context.SaveChanges();
            }
            return 1;
        }

        public int Delete(Guid id)
        {
            using (var context = new Context())
            {
                var model = context.Users.FirstOrDefault(u => u.Id == id);
                context.Users.Remove(model);
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
