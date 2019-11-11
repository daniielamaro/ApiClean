using ApiClean.Application.Repositories;
using Application.Boundaries.Topic;
using Application.Boundaries.User;
using System;

namespace Application.UseCases.Topic.Delete
{
    public class TopicDeleteUseCase : ITopicDeleteUseCase
    {
        private readonly IOutputPortTopic output;
        private readonly ITopicWriteOnlyRepository topicWriteOnlyRepository;

        public TopicDeleteUseCase(IOutputPortTopic output, ITopicWriteOnlyRepository topicWriteOnlyRepository)
        {
            this.output = output;
            this.topicWriteOnlyRepository = topicWriteOnlyRepository;
        }

        public void Execute(TopicDeleteRequest request)
        {
            try
            {
                var ret = topicWriteOnlyRepository.Delete(request.TopicId);
                if (ret == 0)
                {
                    output.Error($"Error on process Delete Topic");
                    return;
                }
                output.Standard(request.TopicId);
            }
            catch (Exception ex)
            {
                output.Error($"Error on process: {ex.Message}");
            }
        }
    }
}
