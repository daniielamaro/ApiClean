using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases.User.Save;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.User.Update
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserPresenter presenter;
        private readonly IUserSaveUseCase userSaveUseCase;

        public UserController(UserPresenter presenter, IUserSaveUseCase userSaveUseCase)
        {
            this.presenter = presenter;
            this.userSaveUseCase = userSaveUseCase;
        }

        [HttpPut]
        [Route("UpdateUser")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]

        public IActionResult UpdateUser([FromBody] InputUser input)
        {
            var request = new UserSaveRequest(input.Id, input.Name, input.Email, input.Password);
            userSaveUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}