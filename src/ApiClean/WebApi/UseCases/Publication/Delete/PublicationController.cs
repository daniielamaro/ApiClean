using Application.UseCases.Publication.Delete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.UseCases.Publication.Delete
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        private readonly PublicationPresenter presenter;
        private readonly IPublicationDeleteUseCase publicationDeleteUseCase;

        public PublicationController(PublicationPresenter presenter, IPublicationDeleteUseCase publicationDeleteUseCase)
        {
            this.presenter = presenter;
            this.publicationDeleteUseCase = publicationDeleteUseCase;
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult DeletePublication([FromBody] InputPublication input)
        {
            var request = new PublicationDeleteRequest(input.PublicationId);
            publicationDeleteUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
