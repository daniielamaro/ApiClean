using Application.UseCases.Comment.Save;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.UseCases.Comment.Update
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

        [HttpPut]
        [Route("UpdateCustomer")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult UpdateCustomer([FromBody] InputComment input)
        {
            var request = new CommentSaveRequest(input.CommentId, input.Autor, input.Content, input.PublicationId);
            commentSaveUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
