﻿using Application.UseCases.Publication.Save;
using Application.UseCases.Topic.Save;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace XUnitTest.Cases.Application.Publication.Save
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("ApiClean.Tests.TestCaseOrdering.PriorityOrderer", "ApiClean.Tests")]
    public class PublicationSaveUseCaseTests
    {
        private readonly IPublicationSaveCase publicationSaveUseCase;
        private readonly PublicationPresenter presenter;
        private static Guid PublicationId;

        public PublicationSaveUseCaseTests(IPublicationSaveCase publicationSaveUseCase, PublicationPresenter presenter)
        {
            this.publicationSaveUseCase = publicationSaveUseCase;
            this.presenter = presenter;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddNewCustomerAndReturnOK()
        {
            var request = new PublicationSaveRequest("TopicTest");
            PublicationId = request.Publication.Id;
            publicationSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldUpdateCustomerAndReturnOK()
        {
            var request = new PublicationSaveRequest("TopicTestUpdate");
            publicationSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ShouldNotAddNewCustomerAndReturnError()
        {
            var request = new PublicationSaveRequest("");
            publicationSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldNotUpdateCustomerAndReturnError()
        {
            var request = new PublicationSaveRequest(PublicationId, "");
            publicationSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}

