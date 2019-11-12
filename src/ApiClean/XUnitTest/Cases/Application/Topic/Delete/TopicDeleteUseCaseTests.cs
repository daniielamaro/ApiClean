using ApiClean.Application.Repositories;
using Application.UseCases.Topic.Delete;
using Application.UseCases.User.Delete;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.UseCases.Topic;
using Xunit;
using Xunit.Frameworks.Autofac;
using ApiClean.Tests.XUnitTest.Builders;
using ApiClean.Application.UseCases.User.Delete;

namespace ApiClean.Tests.XUnitTest.Cases.Application.Topic.Delete
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("ApiClean.Tests.TestCaseOrdering.PriorityOrderer", "ApiClean.Tests")]
    public class PublicationDeleteUseCaseTests
    {
        private readonly ITopicDeleteUseCase topicDeleteUseCase;
        private readonly TopicPresenter presenter;
        private readonly ITopicWriteOnlyRepository topicWriteOnlyRepository;
        private static Guid TopicId;

        public PublicationDeleteUseCaseTests(ITopicDeleteUseCase topicDeleteUseCase, TopicPresenter presenter, ITopicWriteOnlyRepository topicWriteOnlyRepository)
        {
            this.topicDeleteUseCase = topicDeleteUseCase;
            this.presenter = presenter;
            this.topicWriteOnlyRepository = topicWriteOnlyRepository;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddSomeCustomer()
        {
            var model = TopicBuilder.New().Build();
            TopicId = model.Id;
            var ret = topicWriteOnlyRepository.Add(model);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldDeleteCustomer()
        {
            var request = new UserDeleteRequest(TopicId);
            topicDeleteUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldDeleteCustomerAndReturnError()
        {
            var request = new UserDeleteRequest(Guid.NewGuid());
            topicDeleteUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
