using System;
using Application.UseCases.Topic.Get;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.Topic.Get
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly TopicPresenter presenter;
        private readonly ITopicGetUseCase topicGetUseCase;

        public TopicController(TopicPresenter presenter, ITopicGetUseCase topicGetUseCase)
        {
            this.presenter = presenter;
            this.topicGetUseCase = topicGetUseCase;
        }

        [HttpPost]
        [Route("GetTopic")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult DeleteTopic([FromBody] InputTopic input)
        {
            var request = new TopicGetRequest(input.TopicId);
            topicGetUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}