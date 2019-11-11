using Application.Boundaries.Comment;
using Application.UseCases.Comment.Save.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Comment.Save
{
    public class CommentSaveUseCase : ICommentSaveUseCase
    {
        private readonly IOutputPortComment output;
        private readonly ValidateHandler validateHandler;

        public CommentSaveUseCase(IOutputPortComment output, ValidateHandler validateHandler, SaveHandler saveHandler)
        {
            this.output = output;
            this.validateHandler = validateHandler;
            this.validateHandler.SetSucessor(saveHandler);
        }
        public void Execute(CommentSaveRequest request)
        {
            try
            {
                validateHandler.ProcessRequest(request);
                output.Standard(request.Comment.Id);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
