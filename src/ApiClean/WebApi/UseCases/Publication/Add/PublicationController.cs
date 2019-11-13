using System;
using ApiClean.Application.UseCases.Publication.Save;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.Publication.Add
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        private readonly PublicationPresenter presenter;
        private readonly IPublicationSaveCase publicationSaveCase;

        public PublicationController(PublicationPresenter presenter, IPublicationSaveCase publicationSaveUseCase)
        {
            this.presenter = presenter;
            this.publicationSaveCase = publicationSaveUseCase;
        }

        [HttpPost]
        [Route("CreatePublication")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult CreatePublication([FromBody] InputPublication input)
        {
            
            var request = new PublicationSaveRequest(input.Autor, input.Title, input.Content, input.DateCreated, input.Comments, input.Topic);
            publicationSaveCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
