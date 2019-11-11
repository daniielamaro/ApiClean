using ApiClean.Application.Repositories;
using Application.Boundaries.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Comment.Get
{
    public class CommentGetUseCase : ICommentGetUseCase
    {
        private readonly IOutputPortComment output;
        private readonly ICommentReadOnlyRepository commentReadOnlyRepository;

        public CommentGetUseCase(IOutputPortComment output, ICommentReadOnlyRepository commentReadOnlyRepository)
        {
            this.output = output;
            this.commentReadOnlyRepository = commentReadOnlyRepository;
        }

        public void Execute(CommentGetRequest request)
        {
            try
            {
                var comment = commentReadOnlyRepository.GetById(request.CommentId);
                if (comment == null)
                {
                    output.NotFound($"Not found customer with id: {request.CommentId}");
                    return;
                }
                output.Standard(comment);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
