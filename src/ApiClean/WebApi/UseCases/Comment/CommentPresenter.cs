using ApiClean.Application.Boundaries.Comment;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.UseCases.Comment
{
    public class CommentPresenter : IOutputPortComment
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "An error occurred",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void NotFound(string message)
            => ViewModel = new NotFoundObjectResult(message);

        public void Standard(Guid id)
            => ViewModel = new OkObjectResult(id);

        public void Standard(ApiClean.Domain.Comment.Comment comment)
            => ViewModel = new OkObjectResult(new CommentResponse(comment.Id, comment.Autor, comment.Content));

        public void Standard(IList<ApiClean.Domain.Comment.Comment> comments)
        {
            var commentsResponse = new List<CommentResponse>();
            comments.ToList().ForEach(c => commentsResponse.Add(new CommentResponse(c.Id, c.Autor, c.Content)));
            ViewModel = new OkObjectResult(commentsResponse);
        }
    }
}
