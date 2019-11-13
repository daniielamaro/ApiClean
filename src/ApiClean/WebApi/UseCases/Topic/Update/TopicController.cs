using System;
using Application.UseCases.Topic.Save;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.Topic.Update
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {

        private readonly TopicPresenter presenter;
        private readonly ITopicSaveCase topicSaveUseCase;

        public TopicController(TopicPresenter presenter, ITopicSaveCase topicSaveUseCase)
        {
            this.presenter = presenter;
            this.topicSaveUseCase = topicSaveUseCase;
        }

        [HttpPut]
        [Route("UpdateTopic")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult UpdateTopic([FromBody] InputTopic input)
        {
            var request = new TopicSaveRequest(input.Id, input.Name);
            topicSaveUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}