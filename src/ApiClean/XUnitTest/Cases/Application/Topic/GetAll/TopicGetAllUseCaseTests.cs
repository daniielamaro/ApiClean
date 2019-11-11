using Application.UseCases.User.GetAll;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.UseCases.User;
using Xunit;

namespace XUnitTest.Cases.Application.Topic.GetAll
{
    public class TopicGetAllUseCaseTests
    {
        private readonly IUserGetAll userGetAllUseCase;
        private readonly UserPresenter presenter;

        public TopicGetAllUseCaseTests(IUserGetAll userGetAllUseCase, UserPresenter presenter)
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
