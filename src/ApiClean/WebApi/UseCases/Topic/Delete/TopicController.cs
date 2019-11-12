using System;
using Application.UseCases.Topic.Delete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.Topic.Delete
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly TopicPresenter presenter;
        private readonly ITopicDeleteUseCase topicDeleteUseCase;

        public TopicController(TopicPresenter presenter, ITopicDeleteUseCase topicDeleteUseCase)
        {
            this.presenter = presenter;
            this.topicDeleteUseCase = topicDeleteUseCase;
        }

        [HttpDelete]
        [Route("DeleteTopic")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult DeleteCustomer([FromBody] InputTopic input)
        {
            var request = new TopicDeleteRequest(input.TopicId);
            topicDeleteUseCase.Execute(request);
            return presenter.ViewModel;
        }
    }
}