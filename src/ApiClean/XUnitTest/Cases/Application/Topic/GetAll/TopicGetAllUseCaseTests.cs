using ApiClean.Application.UseCases.Topic.GetAll;
using ApiClean.Application.UseCases.User.GetAll;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.UseCases.Topic;
using Xunit;

namespace ApiClean.Tests.XUnitTest.Cases.Application.Topic.GetAll
{
    public class PublicationGetAllUseCaseTests
    {
        private readonly ITopicGetAllUseCase topicGetAllUseCase;
        private readonly TopicPresenter presenter;

        public PublicationGetAllUseCaseTests(ITopicGetAllUseCase topicGetAllUseCase, TopicPresenter presenter)
        {
            this.topicGetAllUseCase = topicGetAllUseCase;
            this.presenter = presenter;
        }

        [Fact]
        public void ShouldExecute()
        {
            topicGetAllUseCase.Execute();
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }
    }
}
