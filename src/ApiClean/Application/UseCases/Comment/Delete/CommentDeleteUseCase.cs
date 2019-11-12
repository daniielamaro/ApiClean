using ApiClean.Application.Repositories;
using Application.Boundaries.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.UseCases.Comment.Delete
{
    public class CommentDeleteUseCase : ICommentDeleteUseCase
    {
        private readonly IOutputPortComment output;
        private readonly ICommentWriteOnlyRepository commentWriteOnlyRepository;

        public CommentDeleteUseCase(IOutputPortComment output, ICommentWriteOnlyRepository commentWriteOnlyRepository)
        {
            this.output = output;
            this.commentWriteOnlyRepository = commentWriteOnlyRepository;
        }

        public void Execute(CommentDeleteRequest request)
        {
            try
            {
                var ret = commentWriteOnlyRepository.Delete(request.CommentId);
                if (ret == 0)
                {
                    output.Error($"Error on process Delete Customer");
                    return;
                }
                output.Standard(request.CommentId);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
