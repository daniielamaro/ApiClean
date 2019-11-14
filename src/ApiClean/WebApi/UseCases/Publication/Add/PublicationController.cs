using System;
using Application.UseCases.Publication.Save;
using Application.UseCases.Topic.Get;
using Application.UseCases.User.Get;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.Publication.Add
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : ControllerBase
    {
        private readonly PublicationPresenter presenter;
        private readonly IPublicationSaveCase publicationSaveCase;
        private readonly IUserGetUseCase userGetUseCase;
        private readonly ITopicGetUseCase topicGetUseCase;

        public PublicationController(PublicationPresenter presenter, IPublicationSaveCase publicationSaveUseCase, IUserGetUseCase userGetUseCase, ITopicGetUseCase topicGetUseCase)
        {
            this.presenter = presenter;
            this.publicationSaveCase = publicationSaveUseCase;
            this.userGetUseCase = userGetUseCase;
            this.topicGetUseCase = topicGetUseCase;
        }

        [HttpPost]
        [Route("CreatePublication")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult CreatePublication([FromBody] InputPublication input)
        {   
            var userRequest = new UserGetRequest(input.AutorId);
            var autor = userGetUseCase.GetObject(userRequest);

            var topicRequest = new TopicGetRequest(input.TopicId);
            var topic = topicGetUseCase.GetObject(topicRequest);

            var request = new PublicationSaveRequest(
                autor,
                input.Title,
                input.Content,
                topic
            );

            publicationSaveCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
