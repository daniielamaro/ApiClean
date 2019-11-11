using ApiClean.Application.Repositories;
using Application.UseCases.Topic.Get;
using Application.UseCases.User.Get;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.UseCases.User;
using Xunit;
using Xunit.Frameworks.Autofac;
using XUnitTest.Builders;

namespace XUnitTest.Cases.Application.Topic.Get
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("ApiClean.Tests.TestCaseOrdering.PriorityOrderer", "ApiClean.Tests")]
    public class PublicationGetUseCaseTests
    {
        public class CustomerGetUseCaseTests
        {
            private readonly ITopicGetUseCase topicGetUseCase;
            private readonly TopicPresenter presenter;
            private readonly ITopicWriteOnlyRepository topicWriteOnlyRepository;
            private static Guid UserId;

            public CustomerGetUseCaseTests(ITopicGetUseCase topicGetUseCase, UserPresenter presenter, ITopicWriteOnlyRepository topicWriteOnlyRepository)
            {
                this.topicGetUseCase = topicGetUseCase;
                this.presenter = presenter;
                this.topicWriteOnlyRepository = topicWriteOnlyRepository;
            }

            [Fact]
            [TestPriority(1)]
            public void ShouldAddSomeCustomer()
            {
                var model = TopicBuilder.New().Build();
                UserId = model.Id;
                var ret = topicWriteOnlyRepository.Add(model);
                ret.Should().Be(1);
            }

            [Fact]
            [TestPriority(2)]
            public void ShouldGetCustomerById()
            {
                var request = new TopicGetRequest(UserId);
                topicGetUseCase.Execute(request);
                presenter.ViewModel.Should().BeOfType<OkObjectResult>();
            }

            [Fact]
            [TestPriority(2)]
            public void ShouldNotGetCustomerByIdAndReturnNotFound()
            {
                var request = new TopicGetRequest(Guid.NewGuid());
                topicGetUseCase.Execute(request);
                presenter.ViewModel.Should().BeOfType<NotFoundObjectResult>();
            }
        }
    }
}
