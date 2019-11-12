using Application.UseCases.Comment.GetAll;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.UseCases.Comment.GetAll
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentPresenter presenter;
        private readonly ICommentGetAllUseCase commentGetAllUseCase;

        public CommentController(CommentPresenter presenter, ICommentGetAllUseCase commentGetAllUseCase)
        {
            this.presenter = presenter;
            this.commentGetAllUseCase = commentGetAllUseCase;
        }

        [HttpPost]
        [Route("GetAllCustomer")]
        [ProducesResponseType(typeof(List<CommentResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetAllCustomers()
        {
            commentGetAllUseCase.Execute();
            return presenter.ViewModel;
        }
    }
}
