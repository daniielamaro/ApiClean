using Application.UseCases.User.Get;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.User.Get
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserPresenter presenter;
        private readonly IUserGetUseCase userGetUseCase;

        public UserController(UserPresenter presenter, IUserGetUseCase userGetUseCase)
        {
            this.presenter = presenter;
            this.userGetUseCase = userGetUseCase;
        }

        [HttpPost]
        [Route("GetUser")]
        [ProducesResponseType(typeof(UserResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]

        public IActionResult GetUser([FromBody] InputUser input)
        {
            var request = new UserGetRequest(input.UserId);
            userGetUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}