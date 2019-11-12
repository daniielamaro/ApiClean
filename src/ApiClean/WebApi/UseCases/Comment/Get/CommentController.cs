using Application.UseCases.Comment.Get;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.UseCases.Comment.Get
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentPresenter presenter;
        private readonly ICommentGetUseCase commentGetUseCase;

        public CommentController(CommentPresenter presenter, ICommentGetUseCase commentGetUseCase)
        {
            this.presenter = presenter;
            this.commentGetUseCase = commentGetUseCase;
        }

        [HttpPost]
        [Route("GetComment")]
        [ProducesResponseType(typeof(CommentResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetCustomer([FromBody] InputComment input)
        {
            var request = new CommentGetRequest(input.Id);
            commentGetUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
