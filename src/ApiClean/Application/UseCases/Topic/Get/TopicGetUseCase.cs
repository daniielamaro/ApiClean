﻿using ApiClean.Application.Repositories;
using Application.Boundaries.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Topic.Get
{
    public class TopicGetUseCase
    {
        private readonly IOutputPort<Domain.Topic.Topic> output;
        private readonly ITopicReadOnlyRepository topicReadOnlyRepository;

        public TopicGetUseCase(IOutputPort output, ITopicReadOnlyRepository topicReadOnlyRepository)
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
                    output.NotFound($"Not found customer with id: {request.TopicId}");
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
