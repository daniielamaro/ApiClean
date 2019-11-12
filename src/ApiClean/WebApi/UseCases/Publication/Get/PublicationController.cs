using Application.UseCases.Publication.Get;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.Publication.Get
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        private readonly PublicationPresenter presenter;
        private readonly IPublicationGetUseCase publicationGetUseCase;

        public PublicationController(PublicationPresenter presenter, IPublicationGetUseCase publicationGetUseCase)
        {
            this.presenter = presenter;
            this.publicationGetUseCase = publicationGetUseCase;
        }

        [HttpPost]
        [Route("GetCustomer")]
        [ProducesResponseType(typeof(PublicationResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetPublication([FromBody] InputPublication input)
        {
            var request = new PublicationGetRequest(input.PublicationId);
            publicationGetUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
