using Application.UseCases.User.GetAll;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.UseCases.User.GetAll
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserPresenter presenter;
        private readonly IUserGetAllUseCase userGetAllUseCase;

        public UserController(UserPresenter presenter, IUserGetAllUseCase userGetAllUseCase)
        {
            this.presenter = presenter;
            this.userGetAllUseCase = userGetAllUseCase;
        }

        [HttpPost]
        [Route("GetAllUser")]
        [ProducesResponseType(typeof(List<UserResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetAllUser()
        {
            userGetAllUseCase.Execute();
            return presenter.ViewModel;
        }
    }
}