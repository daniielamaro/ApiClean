using Application.UseCases.User.Save;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.UseCases.User.Add
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserPresenter presenter;
        private readonly IUserSaveUseCase userSaveUseCase;

        public UserController(UserPresenter presenter, IUserSaveUseCase userSave)
        {
            this.presenter = presenter;
            this.userSaveUseCase = userSave;
        }

        [HttpPost]
        [Route("CreateUser")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult CreateUser([FromBody] InputUser input)
        {
            var request = new UserSaveRequest(input.Name, input.Email, input.Password);
            userSaveUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
