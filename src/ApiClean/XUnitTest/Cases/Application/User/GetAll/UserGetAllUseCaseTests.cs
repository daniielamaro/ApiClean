using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using ApiClean.WebApi.UseCases.User;
using ApiClean.Application.UseCases.User.GetAll;
using Xunit;

namespace ApiClean.Tests.XUnitTest.Cases.Application.User.GetAll
{
    public class UserGetAllUseCaseTests
    {
        private readonly IUserGetAll userGetAllUseCase;
        private readonly UserPresenter presenter;

        public UserGetAllUseCaseTests(IUserGetAll userGetAllUseCase, UserPresenter presenter)
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
