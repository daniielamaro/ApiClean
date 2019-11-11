using Application.UseCases.User.GetAll;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.UseCases.User;

namespace XUnitTest.Cases.Application.User.GetAll
{
    class UserGetAllUseCaseTests
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
