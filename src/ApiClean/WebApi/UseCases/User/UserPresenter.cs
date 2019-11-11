using ApiClean.Application.Boundaries.Customer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace WebApi.UseCases.User
{
    public class UserPresenter : IOutputPort
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

        public void Standard(Domain.User.User user)
            => ViewModel = new OkObjectResult(new UserResponse(user.Id, user.Name, user.Age, user.Email));

        public void Standard(IList<Domain.User.User> user)
        {
            var customersResponse = new List<UserResponse>();
            customer.ToList().ForEach(s => UserResponse.Add(new UserResponse(s.Id, s.Name, s.Age, s.Email)));
            ViewModel = new OkObjectResult(UserResponse);
        }
    }
}
