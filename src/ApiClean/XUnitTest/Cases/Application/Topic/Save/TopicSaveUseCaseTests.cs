using ApiClean.Application.UseCases.Topic.Save;
using ApiClean.Tests.TestCaseOrdering;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.UseCases.Topic;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace ApiClean.Tests.XUnitTest.Cases.Application.Topic.Save
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("ApiClean.Tests.TestCaseOrdering.PriorityOrderer", "ApiClean.Tests")]
    public class TopicSaveUseCaseTests
    {
        private readonly ITopicSaveCase topicSaveUseCase;
        private readonly TopicPresenter presenter;
        private static Guid TopicId;

        public TopicSaveUseCaseTests(ITopicSaveCase topicSaveUseCase, TopicPresenter presenter)
        {
            this.topicSaveUseCase = topicSaveUseCase;
            this.presenter = presenter;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddNewCustomerAndReturnOK()
        {
            var request = new TopicSaveRequest("TopicTest");
            TopicId = request.Topic.Id;
            topicSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldUpdateCustomerAndReturnOK()
        {
            var request = new TopicSaveRequest("TopicTestUpdate");
            topicSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ShouldNotAddNewCustomerAndReturnError()
        {
            var request = new TopicSaveRequest("");
            topicSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldNotUpdateCustomerAndReturnError()
        {
            var request = new TopicSaveRequest(TopicId, "");
            topicSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}

