using ApiClean.Application.Repositories
using Application.Boundaries.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Topic.GetAll
{
    public class TopicGetAllUseCase :  ITopicGetAllUseCase
    {
        private readonly ITopicReadOnlyRepository topicsReadOnlyRepository;
        private readonly IOutputPort<Domain.Topic.Topic> output;

        public TopicGetAllUseCase(ITopicReadOnlyRepository topicsReadOnlyRepository, IOutputPort<Domain.Topic.Topic> output)
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
