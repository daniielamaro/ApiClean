using ApiClean.Application.Repositories;
using ApiClean.Application.Boundaries.Topic;
using ApiClean.Application.Boundaries.User;
using System;
using System.Collections.Generic;
using System.Text;
using ApiClean.Application.UseCases.Topic.GetAll;

namespace ApiClean.UseCases.Topic.GetAll
{
    public class TopicGetAllUseCase : ITopicGetAllUseCase
    {
        private readonly ITopicReadOnlyRepository topicsReadOnlyRepository;
        private readonly IOutputPortTopic output;

        public TopicGetAllUseCase(ITopicReadOnlyRepository topicsReadOnlyRepository, IOutputPortTopic output)
        {
            this.topicsReadOnlyRepository = topicsReadOnlyRepository;
            this.output = output;
        }

        public void Execute()
        {
            try
            {
                var topics = topicsReadOnlyRepository.GetAll();
                output.Standard(topics);
            }
            catch (System.Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
