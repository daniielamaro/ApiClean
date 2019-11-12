using Application.UseCases.Topic.GetAll;
using Application.UseCases.User.GetAll;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.UseCases.Topic;
using Xunit;

namespace XUnitTest.Cases.Application.Topic.GetAll
{
    public class PublicationGetAllUseCaseTests
    {
        private readonly ITopicGetAllUseCase userGetAllUseCase;
        private readonly TopicPresenter presenter;

        public PublicationGetAllUseCaseTests(IUserGetAll userGetAllUseCase, TopicPresenter presenter)
        {
            this.userGetAllUseCase = userGetAllUseCase;
            this.presenter = presenter;
        }

        [Fact]
        public void ShouldExecute()
        {
            userGetAllUseCase.Execute();
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }
    }
}
