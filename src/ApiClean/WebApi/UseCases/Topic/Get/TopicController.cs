using System;
using ApiClean.Application.UseCases.Topic.Get;
using Microsoft.AspNetCore.Mvc;
using WebApi.UseCases.Topic;

namespace ApiClean.WebApi.UseCases.Topic.Get
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
        public IActionResult DeleteCustomer([FromBody] InputTopic input)
        {
            var request = new TopicGetRequest(input.TopicId);
            topicGetUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}
