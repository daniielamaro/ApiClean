using System;
using System.Collections.Generic;
using System.Linq;
using Application.Boundaries.Publication;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.Publication
{
    public class PublicationPresenter : IOutputPortPublication
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "An error occurred",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

            public void NotFound(string message)
                => ViewModel = new NotFoundObjectResult(message);

        public void Standard(Guid id)
            => ViewModel = new OkObjectResult(id);

        public void Standard(Domain.Publication.Publication model)
            => ViewModel = new OkObjectResult(new PublicationResponse(model.Id, model.Autor, 
                model.Title, model.Content, model.DateCreated, model.Comments, model.Topic));

        public void Standard(IList<Domain.Publication.Publication> model)
        {
            var publicationsResponse = new List<PublicationResponse>();
            model.ToList().ForEach(s => publicationsResponse.Add(new PublicationResponse(p.Id, p.Autor,
                p.Title, p.Content, p.DateCreated, p.Comments, p.Topic)));
            ViewModel = new OkObjectResult(publicationsResponse);
        }
    }
}
