using ApiClean.Application.Repositories;
using Application.Boundaries.Topic;
using Application.Boundaries.User;
using System;

namespace Application.UseCases.Topic.Get
{
    public class TopicGetUseCase
    {
        private readonly IOutputPortTopic output;
        private readonly ITopicReadOnlyRepository topicReadOnlyRepository;

        public TopicGetUseCase(IOutputPortTopic output, ITopicReadOnlyRepository topicReadOnlyRepository)
        {
            this.output = output;
            this.topicReadOnlyRepository = topicReadOnlyRepository;
        }

        public void Execute(TopicGetRequest request)
        {
            try
            {
                var customer = topicReadOnlyRepository.GetById(request.TopicId);
                if (customer == null)
                {
                    output.NotFound($"Not found topic with id: {request.TopicId}");
                    return;
                }
                output.Standard(customer);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
