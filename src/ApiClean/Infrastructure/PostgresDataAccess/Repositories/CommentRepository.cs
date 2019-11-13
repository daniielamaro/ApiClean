using System.Collections.Generic;
using AutoMapper;
using ApiClean.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System;
using ApiClean.Domain.Comment;

namespace ApiClean.Infrastructure.PostgresDataAccess.Repositories
{
    public class CommentRepository : ICommentReadOnlyRepository, ICommentWriteOnlyRepository
    {
        private readonly IMapper mapper;

        public CommentRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(Comment comment)
        {
            var model = mapper.Map<Comment>(comment);
            using (Context context = new Context())
            {
                context.Comments.Add(model);
                context.SaveChanges();
            }
            return 1;
        }

        public int Add(List<Comment> comments)
        {
            var models = mapper.Map<List<Comment>>(comments);
            using (Context context = new Context())
            {
                context.Comments.AddRange(models);
                context.SaveChanges();
            }
            return 1;
        }

        public int Delete(Guid id)
        {
            using (var context = new Context())
            {
                var model = context.Comments.FirstOrDefault(c => c.Id == id);
                context.Comments.Remove(model);
                return context.SaveChanges();
            }
        }

        public int Delete(Comment comment)
        {
            using (var context = new Context())
            {
                var model = context.Comments.FirstOrDefault(c => c.Id == comment.Id);
                context.Comments.Remove(model);
                return context.SaveChanges();
            }
        }

        public IList<Comment> GetAll()
        {
            var list = new List<Comment>();
            using (var context = new Context())
            {
                list = mapper.Map<List<Comment>>(context.Comments.ToList());
            }
            return list;
        }

        public IList<Comment> GetByFilter(Expression<Func<Comment, bool>> filter)
        {
            using (var context = new Context())
            {
                return mapper.Map<List<Comment>>(context.Comments.Where(mapper.Map<Expression<Func<Comment, bool>>>(filter)).ToList());
            }
        }

        public Comment GetById(Guid id)
        {
            using (var context = new Context())
            {
                return mapper.Map<Comment>(context.Comments.FirstOrDefault(c => c.Id == id));
            }
        }

        public int Save(Comment comment)
        {
            if (GetById(comment.Id) == null)
                return Add(comment);
            else
                return Update(comment);
        }

        public int Update(Comment comment)
        {
            using (var context = new Context())
            {
                context.Entry(mapper.Map<Comment>(comment)).State = EntityState.Modified;
                return context.SaveChanges();
            }
        }
    }
}
