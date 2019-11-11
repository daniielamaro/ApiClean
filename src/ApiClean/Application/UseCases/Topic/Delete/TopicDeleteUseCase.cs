﻿using ApiClean.Application.Repositories;
using Application.Boundaries.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Topic.Delete
{
    public class TopicDeleteUseCase : ITopicDeleteUseCase
    {
        private readonly IOutputPort<Domain.Topic.Topic> output;
        private readonly ITopicWriteOnlyRepository topicWriteOnlyRepository;

        public TopicDeleteUseCase(IOutputPort<Domain.Topic.Topic> output, ITopicWriteOnlyRepository topicWriteOnlyRepository)
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
                    output.Error($"Error on process Delete Customer");
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
