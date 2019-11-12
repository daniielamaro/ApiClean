﻿using System;
using System.Collections.Generic;
using Application.UseCases.Topic.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UseCases.Topic.GetAll
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly PublicationPresenter presenter;
        private readonly ITopicGetAllUseCase topicGetAllUseCase;

        public TopicController(PublicationPresenter presenter, ITopicGetAllUseCase topicGetAllUseCase)
        {
            this.presenter = presenter;
            this.topicGetAllUseCase = topicGetAllUseCase;
        }

        [HttpPost]
        [Route("GetAllTopic")]
        [ProducesResponseType(typeof(List<PublicationResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        public IActionResult GetAllTopics()
        {
            topicGetAllUseCase.Execute();
            return presenter.ViewModel;
        }
    }
}