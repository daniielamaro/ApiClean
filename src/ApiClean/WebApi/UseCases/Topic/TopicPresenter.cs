using ApiClean.Application.Boundaries.Customer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace WebApi.UseCases.Topic
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

        public void Standard(Domain.Topic.Topic topic)
            => ViewModel = new OkObjectResult(new TopicResponse(topic.Id, topic.Name));

        public void Standard(IList<Domain.Topic.Topic> topic)
        {
            var customersResponse = new List<TopicResponse>();
            customer.ToList().ForEach(t => TopicResponse.Add(new TopicResponse(t.Id, t.Name)));
            ViewModel = new OkObjectResult(TopicResponse);
        }
    }
}
