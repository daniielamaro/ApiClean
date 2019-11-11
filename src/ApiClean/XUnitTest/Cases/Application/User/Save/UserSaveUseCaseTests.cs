using Application.UseCases.User.Save;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.UseCases.User;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace XUnitTest.Cases.Application.User.Save
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("ApiClean.Tests.TestCaseOrdering.PriorityOrderer", "ApiClean.Tests")]

    public class UserSaveUseCaseTests
    {
        private readonly IUserSave userSaveUseCase;
        private readonly UserPresenter presenter;
        private static Guid UserId;

        public UserSaveUseCaseTests(IUserSave userSaveUseCase, UserPresenter presenter)
        {
            this.userSaveUseCase = userSaveUseCase;
            this.presenter = presenter;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddNewCustomerAndReturnOK()
        {
            var request = new UserSaveRequest("UserTest", "user@hotmail.com", "user1234");
            UserId = request.User.Id;
            userSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldUpdateCustomerAndReturnOK()
        {
            var request = new UserSaveRequest(UserId, "CustomerTestUpdated", "userUpdate@hotmail.com", "user1234");
            userSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ShouldNotAddNewCustomerAndReturnError()
        {
            var request = new UserSaveRequest("UserTest", "user@hotmail.com", "");
            userSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldNotUpdateCustomerAndReturnError()
        {
            var request = new UserSaveRequest(UserId, "", "user@hotmail.com", "user1234");
            userSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}

