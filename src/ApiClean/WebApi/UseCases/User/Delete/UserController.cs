using Application.UseCases.User.Delete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.UseCases.User.Delete
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserPresenter presenter;
        private readonly IUserDeleteUseCase userDeleteUseCase;

        public UserController(UserPresenter presenter, IUserDeleteUseCase userDeleteUseCase)
        {
            this.presenter = presenter;
            this.userDeleteUseCase = userDeleteUseCase;
        }

        [HttpDelete]
        [Route("DeleteUser")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult DeleteUser([FromBody] InputUser input)
        {
            var request = new UserDeleteRequest(input.UserId);
            userDeleteUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
