using System;
using System.Collections.Generic;
using AutoMapper;
using ApiClean.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Domain.Topic;

namespace Infrastructure.PostgresDataAccess.Repositories
{
    public class TopicRepository : ITopicReadOnlyRepository, ITopicWriteOnlyRepository
    {
        private readonly IMapper mapper;

        public TopicRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(Topic topic)
        {
            var model = mapper.Map<Entities.Topic.Topic>(topic);
            using (Context context = new Context())
            {
                context.Topics.Add(model);
                context.SaveChanges();
            }
            return 1;
        }

        public int Add(List<Topic> topics)
        {
            var models = mapper.Map<List<Entities.Topic.Topic>>(topics);
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

        public int Delete(Topic topic)
        {

            using (var context = new Context())
            {
                var model = context.Users.FirstOrDefault(u => u.Id == user.Id);
                context.Users.Remove(model);
                return context.SaveChanges();
            }
        }

        public IList<Topic> GetAll()
        {
            var list = new List<User>();
            using (var context = new Context())
            {
                list = mapper.Map<List<User>>(context.Users.ToList());
            }
            return list;
        }

        public IList<Topic> GetByFilter(Expression<Func<Topic, bool>> filter)
        {
            using (var context = new Context())
            {
                return mapper.Map<List<User>>(context.Users.Where(mapper.Map<Expression<Func<Entities.Topic.User, bool>>>(filter)).ToList());
            }
        }

        public Topic GetById(Guid id)
        {
            using (var context = new Context())
            {
                return mapper.Map<User>(context.Users.FirstOrDefault(u => u.Id == id));
            }
        }

        public int Save(Topic topic)
        {
            if (GetById(user.Id) == null)
                return Add(user);
            else
                return Update(user);
        }

        public int Update(Topic topic)
        {
            using (var context = new Context())
            {
                context.Entry(mapper.Map<Entities.Topic.User>(user)).State = EntityState.Modified;
                return context.SaveChanges();
            }
        }
    }
}
