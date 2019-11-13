﻿using ApiClean.Application.UseCases.Comment.Save;
using ApiClean.Tests.TestCaseOrdering;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.UseCases.Comment;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace ApiClean.Tests.XUnitTest.Cases.Application.Comment.Save
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("ApiClean.Tests.TestCaseOrdering.PriorityOrderer", "ApiClean.Tests")]
    public class CommentSaveUseCaseTests
    {
        private readonly ICommentSaveUseCase commentSaveUseCase;
        private readonly CommentPresenter presenter;
        private static Guid commentId;

        public CommentSaveUseCaseTests(ICommentSaveUseCase commentSaveUseCase, CommentPresenter presenter)
        {
            this.commentSaveUseCase = commentSaveUseCase;
            this.presenter = presenter;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddNewCustomerAndReturnOK()
        {
            var request = new CommentSaveRequest(Guid.NewGuid(), Builders.UserBuilder.New().Build(), "Comment", Builders.PublicationBuilder.New().Id);
            commentId = request.Comment.Id;
            commentSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldUpdateCustomerAndReturnOK()
        {
            var request = new CommentSaveRequest(Guid.NewGuid(), Builders.UserBuilder.New().Build(), "CommentUpdate", Builders.PublicationBuilder.New().Id);
            commentSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ShouldNotAddNewCustomerAndReturnError()
        {
            var request = new CommentSaveRequest(Guid.NewGuid(), Builders.UserBuilder.New().Build(), "", Builders.PublicationBuilder.New().Id);
            commentSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void ShouldNotUpdateCustomerAndReturnError()
        {
            var request = new CommentSaveRequest(commentId, Builders.UserBuilder.New().Build(), "Comment", Builders.PublicationBuilder.New().Id);
            commentSaveUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}

