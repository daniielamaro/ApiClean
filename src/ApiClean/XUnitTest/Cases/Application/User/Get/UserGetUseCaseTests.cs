using ApiClean.Application.Repositories;
using Application.UseCases.User.Get;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using Tests.TestCaseOrdering;
using Xunit;
using Xunit.Frameworks.Autofac;
using XUnitTest.Builders;

namespace XUnitTest.Cases.Application.User.Get
{

    [UseAutofacTestFramework]
    [TestCaseOrderer("Tests.TestCaseOrdering.PriorityOrderer", "Tests")]
    public class UserGetUseCaseTests
    {
        private readonly IUserGetUseCase userGetUseCase;
        private readonly UserPresenter presenter;
        private readonly IUserWriteOnlyRepository userWriteOnlyRepository;
        private static Guid UserId;

        public UserGetUseCaseTests(IUserGetUseCase userGetUseCase, UserPresenter presenter, IUserWriteOnlyRepository userWriteOnlyRepository)
        {
            this.userGetUseCase = userGetUseCase;
            this.presenter = presenter;
            this.userWriteOnlyRepository = userWriteOnlyRepository;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddSomeUser()
        {
            var model = UserBuilder.New().Build();
            UserId = model.Id;
            var ret = userWriteOnlyRepository.Add(model);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldGetCustomerById()
        {
            var request = new CustomerGetRequest(CustomerId);
            customerGetUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldNotGetCustomerByIdAndReturnNotFound()
        {
            var request = new CustomerGetRequest(Guid.NewGuid());
            customerGetUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<NotFoundObjectResult>();
        }
    }
}
