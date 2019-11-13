using ApiClean.Application.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Frameworks.Autofac;
using ApiClean.Tests.XUnitTest.Builders;
using ApiClean.Application.UseCases.User.Get;
using ApiClean.WebApi.UseCases.User;
using ApiClean.Tests.TestCaseOrdering;

namespace ApiClean.Tests.XUnitTest.Cases.Application.User.Get
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("ApiClean.Tests.TestCaseOrdering.PriorityOrderer", "ApiClean.Tests")]
    class UserGetUseCaseTests
    {
        public class CustomerGetUseCaseTests
        {
            private readonly IUserGet userGetUseCase;
            private readonly UserPresenter presenter;
            private readonly IUserWriteOnlyRepository userWriteOnlyRepository;
            private static Guid UserId;

            public CustomerGetUseCaseTests(IUserGet userGetUseCase, UserPresenter presenter, IUserWriteOnlyRepository userWriteOnlyRepository)
            {
                this.userGetUseCase = userGetUseCase;
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
            public void ShouldGetCustomerById()
            {
                var request = new UserGetRequest(UserId);
                userGetUseCase.Execute(request);
                presenter.ViewModel.Should().BeOfType<OkObjectResult>();
            }

            [Fact]
            [TestPriority(2)]
            public void ShouldNotGetCustomerByIdAndReturnNotFound()
            {
                var request = new UserGetRequest(Guid.NewGuid());
                userGetUseCase.Execute(request);
                presenter.ViewModel.Should().BeOfType<NotFoundObjectResult>();
            }
        }
    }
}
