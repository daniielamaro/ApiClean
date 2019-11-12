using Application.UseCases.Publication.GetAll;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.UseCases.Publication.GetAll
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        private readonly PublicationPresenter presenter;
        private readonly IPublicationGetAllUseCase publicationGetAllUseCase;

        public PublicationController(PublicationPresenter presenter, IPublicationGetAllUseCase publicationGetAllUseCase)
        {
            this.presenter = presenter;
            this.publicationGetAllUseCase = publicationGetAllUseCase;
        }

        [HttpPost]
        [Route("GetAllCustomer")]
        [ProducesResponseType(typeof(List<PublicationResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult GetAllPublications()
        {
            publicationGetAllUseCase.Execute();
            return presenter.ViewModel;
        }
    }
}
