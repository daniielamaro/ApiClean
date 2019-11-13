using System;
using System.Collections.Generic;
using Application.UseCases.Publication.Save;
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
        private readonly Context context;

        public PublicationController(PublicationPresenter presenter, IPublicationSaveCase publicationSaveUseCase)
        {
            this.presenter = presenter;
            this.publicationSaveCase = publicationSaveUseCase;
            context = new Context();
        }

        [HttpPost]
        [Route("CreatePublication")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult CreatePublication([FromBody] InputPublication input)
        {
            var autorTemp = context.Users.Find(input.AutorId);
            var autor = new Domain.User.User(
                autorTemp.Id,
                autorTemp.Name,
                autorTemp.Email,
                autorTemp.Password
            );
            var topicTemp = context.Topics.Find(input.TopicId);
            var topic = new Domain.Topic.Topic(
                topicTemp.Id,
                topicTemp.Name
            );

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
