using ApiClean.Application.Repositories;
using Application.Boundaries.Topic;
using Application.Boundaries.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Topic.Get
{
    public class TopicGetUseCase : ITopicGetUseCase
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
                var topic = topicReadOnlyRepository.GetById(request.TopicId);
                if (topic == null)
                {
                    output.NotFound($"Not found topic with id: {request.TopicId}");
                    return;
                }
                output.Standard(topic);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
