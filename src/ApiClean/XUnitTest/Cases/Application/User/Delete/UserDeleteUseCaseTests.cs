using ApiClean.Application.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using ApiClean.WebApi.UseCases.User;
using Xunit;
using Xunit.Frameworks.Autofac;
using ApiClean.Tests.XUnitTest.Builders;
using ApiClean.Application.UseCases.User.Delete;
using ApiClean.Tests.TestCaseOrdering;

namespace ApiClean.Tests.XUnitTest.Cases.Application.User.Delete
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("ApiClean.Tests.TestCaseOrdering.PriorityOrderer", "ApiClean.Tests")]
    public class UserDeleteUseCaseTests
    {
        private readonly IUserDelete userDeleteUseCase;
        private readonly UserPresenter presenter;
        private readonly IUserWriteOnlyRepository userWriteOnlyRepository;
        private static Guid UserId;

        public UserDeleteUseCaseTests(IUserDelete userDeleteUseCase, UserPresenter presenter, IUserWriteOnlyRepository userWriteOnlyRepository)
        {
            this.userDeleteUseCase = userDeleteUseCase;
            this.presenter = presenter;
            this.userWriteOnlyRepository = userWriteOnlyRepository;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddSomeCustomer()
        {
            var model = UserBuilder.New().Build();
            UserId = model.Id;
            var ret = userWriteOnlyRepository.Add(model);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldDeleteCustomer()
        {
            var request = new UserDeleteRequest(UserId);
            userDeleteUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldDeleteCustomerAndReturnError()
        {
            var request = new UserDeleteRequest(Guid.NewGuid());
            userDeleteUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
