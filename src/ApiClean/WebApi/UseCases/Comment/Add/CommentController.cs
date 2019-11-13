using System;
using ApiClean.Application.UseCases.Comment.Save;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.Comment.Add
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentPresenter presenter;
        private readonly ICommentSaveUseCase commentSaveUseCase;

        public CommentController(CommentPresenter presenter, ICommentSaveUseCase commentSaveUseCase)
        {
            this.presenter = presenter;
            this.commentSaveUseCase = commentSaveUseCase;
        }

        [HttpPost]
        [Route("CreateComment")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]

        public IActionResult CreateComent([FromBody] InputComment input)
        {
            var request = new CommentSaveRequest(input.User, input.Content, input.PublicationId);
            commentSaveUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}