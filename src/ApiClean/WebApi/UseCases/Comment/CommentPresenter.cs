using Application.Boundaries.Comment;
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

        public void Standard(Domain.Comment.Comment comment)
            => ViewModel = new OkObjectResult(new CommentResponse(comment.Id, comment.Autor, comment.Content, comment.PublicationId));

        public void Standard(IList<Domain.Comment.Comment> comments)
        {
            var customersResponse = new List<CommentResponse>();
            comments.ToList().ForEach(s => customersResponse.Add(new CommentResponse(s.Id, s.Autor, s.Content, s.PublicationId)));
            ViewModel = new OkObjectResult(customersResponse);
        }
    }
}
