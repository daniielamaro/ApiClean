using Application.UseCases.Publication.Get;
using Application.UseCases.Publication.Save;
using Application.UseCases.Topic.Get;
using Application.UseCases.User.Get;
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
        private readonly IPublicationGetUseCase publicationGetUseCase;
        private readonly ITopicGetUseCase topicGetUseCase;

        public PublicationController(PublicationPresenter presenter, IPublicationSaveCase publicationSaveUseCase, IPublicationGetUseCase publicationGetUseCase, ITopicGetUseCase topicGetUseCase)
        {
            this.presenter = presenter;
            this.publicationSaveUseCase = publicationSaveUseCase;
            this.publicationGetUseCase = publicationGetUseCase;
            this.topicGetUseCase = topicGetUseCase;
        }

        [HttpPut]
        [Route("UpdatePublication")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult UpdatePublication([FromBody] InputPublication input)
        {
            var publicationRequest = new PublicationGetRequest(input.Id);
            var publication = publicationGetUseCase.GetObject(publicationRequest);

            var topicRequest = new TopicGetRequest(input.TopicId);
            var topic = topicGetUseCase.GetObject(topicRequest);

            var request = new PublicationSaveRequest(input.Id, publication.Autor, input.Title, input.Content, publication.DateCreated, publication.Comments, topic);

            publicationSaveUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
