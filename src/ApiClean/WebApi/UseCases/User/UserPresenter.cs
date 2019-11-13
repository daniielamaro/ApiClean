using ApiClean.Application.Boundaries.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ApiClean.WebApi.UseCases.User
{
    public class UserPresenter : IOutputPortUser
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "An error as ocurred",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void NotFound(string message)
            => ViewModel = new NotFoundObjectResult(message);

        public void Standard(Guid id)
           => ViewModel = new OkObjectResult(id);

        public void Standard(ApiClean.Domain.User.User user)
            => ViewModel = new OkObjectResult(new UserResponse(user.Id, user.Name, user.Email, user.Password));

        public void Standard(IList<ApiClean.Domain.User.User> user)
        {
            var usersResponse = new List<UserResponse>();
            user.ToList().ForEach(s => usersResponse.Add(new UserResponse(s.Id, s.Name, s.Email, s.Password)));
            ViewModel = new OkObjectResult(usersResponse);
        }
    }
}
