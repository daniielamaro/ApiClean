using Application.UseCases.Comment.Delete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.UseCases.Comment.Delete
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentPresenter presenter;
        private readonly ICommentDeleteUseCase commentDeleteUseCase;

        public CommentController(CommentPresenter presenter, ICommentDeleteUseCase commentDeleteUseCase)
        {
            this.presenter = presenter;
            this.commentDeleteUseCase = commentDeleteUseCase;
        }

        [HttpDelete]
        [Route("DeleteComment")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult DeleteCustomer([FromBody] InputComment input)
        {
            var request = new CommentDeleteRequest(input.Id);
            commentDeleteUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
