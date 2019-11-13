﻿using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApi.UseCases.Publication;
using Xunit;
using Xunit.Frameworks.Autofac;
using ApiClean.Application.UseCases.Publication.Save;
using ApiClean.Tests.TestCaseOrdering;

namespace ApiClean.Tests.XUnitTest.Cases.Application.Publication.Save
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
/*        public User.User Autor { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime DateCreated { get; private set; }
        public List<Comment.Comment> Comments { get; private set; }
        public Topic.Topic Topic { get; private set; }*/

        [Fact]
        [TestPriority(1)]
        public void ShouldAddNewPublicationAndReturnOK()
        { 
            var request = new PublicationSaveRequest(Builders.UserBuilder.New().Build(), "Title", "Content", DateTime.Now, new List<ApiClean.Domain.Comment.Comment>(), Builders.TopicBuilder.New().Build());
            PublicationId = request.Publication.Id;
            publicationSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldUpdatePublicationAAndReturnOK()
        {
            var request = new PublicationSaveRequest(Builders.UserBuilder.New().Build(), "Title", "ContentUpdate", DateTime.Now, new List<ApiClean.Domain.Comment.Comment>(), Builders.TopicBuilder.New().Build());
            publicationSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ShouldNotAddNewCustomerAndReturnError()
        {
            var request = new PublicationSaveRequest(Builders.UserBuilder.New().Build(), "", "", DateTime.Now, new List<ApiClean.Domain.Comment.Comment>(), Builders.TopicBuilder.New().Build());
            publicationSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldNotUpdateCustomerAndReturnError()
        {
            var request = new PublicationSaveRequest(PublicationId, Builders.UserBuilder.New().Build(), "Title", "Content", DateTime.Now, new List<ApiClean.Domain.Comment.Comment>(), Builders.TopicBuilder.New().Build());
            publicationSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}

