using Application.UseCases.Publication.Save;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.UseCases.Publication.Update
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        private readonly PublicationPresenter presenter;
        private readonly IPublicationSaveCase publicationSaveUseCase;

        public PublicationController(PublicationPresenter presenter, IPublicationSaveCase publicationSaveUseCase)
        {
            this.presenter = presenter;
            this.publicationSaveUseCase = publicationSaveUseCase;
        }

        [HttpPut]
        [Route("UpdatePublication")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult UpdatePublication([FromBody] InputPublication input)
        {
            var request = new PublicationSaveRequest(input.Autor, input.Title, input.Content, input.Topic);
            publicationSaveUseCase.Execute(request);
            return presenter.ViewModel;

        }
    }
}
