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
                context.Topics.AddRange(models);
                context.SaveChanges();
            }
            return 1;
        }

        public int Delete(Guid id)
        {

            using (var context = new Context())
            {
                var model = context.Topics.FirstOrDefault(t => t.Id == id);
                context.Topics.Remove(model);
                return context.SaveChanges();
            }
        }

        public int Delete(Topic topic)
        {

            using (var context = new Context())
            {
                var model = context.Topics.FirstOrDefault(t => t.Id == topic.Id);
                context.Topics.Remove(model);
                return context.SaveChanges();
            }
        }

        public IList<Topic> GetAll()
        {
            var list = new List<Topic>();
            using (var context = new Context())
            {
                list = mapper.Map<List<Topic>>(context.Topics.ToList());
            }
            return list;
        }

        public IList<Topic> GetByFilter(Expression<Func<Topic, bool>> filter)
        {
            using (var context = new Context())
            {
                return mapper.Map<List<Topic>>(context.Topics.Where(mapper.Map<Expression<Func<Entities.Topic.Topic, bool>>>(filter)).ToList());
            }
        }

        public Topic GetById(Guid id)
        {
            using (var context = new Context())
            {
                return mapper.Map<Topic>(context.Topics.FirstOrDefault(t => t.Id == id));
            }
        }

        public int Save(Topic topic)
        {
            if (GetById(topic.Id) == null)
                return Add(topic);
            else
                return Update(topic);
        }

        public int Update(Topic topic)
        {
            using (var context = new Context())
            {
                context.Entry(mapper.Map<Entities.Topic.Topic>(topic)).State = EntityState.Modified;
                return context.SaveChanges();
            }
        }
    }
}
