using System;
using ApiClean.Application.UseCases.Topic.Save;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.Topic.Save
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly TopicPresenter presenter;
        private readonly ITopicSaveCase topicSaveCase;

        public TopicController(TopicPresenter presenter, ITopicSaveCase topicSaveCase)
        {
            this.presenter = presenter;
            this.topicSaveCase = topicSaveCase;
        }

        [HttpPut]
        [Route("SaveTopic")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult SaveTopic([FromBody] InputTopic input)
        {
            var request = new TopicSaveRequest(input.Id, input.Name);
            topicSaveCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}