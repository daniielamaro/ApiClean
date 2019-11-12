using ApiClean.Application.Repositories;
using Application.Boundaries.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClean.Application.UseCases.Comment.GetAll
{
    public class CommentGetAllUseCase : ICommentGetAllUseCase
    {
        private readonly IOutputPortComment output;
        private readonly ICommentReadOnlyRepository commentReadOnlyRepository;

        public CommentGetAllUseCase(ICommentReadOnlyRepository commentReadOnlyRepository, IOutputPortComment output)
        {
            this.output = output;
            this.commentReadOnlyRepository = commentReadOnlyRepository;
        }

        public void Execute()
        {
            try
            {
                var comments = commentReadOnlyRepository.GetAll();
                output.Standard(comments);
            }
            catch (System.Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
