using ApiClean.Application.Repositories;
using Application.UseCases.Comment.Delete;
using Application.UseCases.Publication.Delete;
using Application.UseCases.Topic.Delete;
using Application.UseCases.User.Delete;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.UseCases.Comment;
using Xunit;
using Xunit.Frameworks.Autofac;
using ApiClean.Tests.XUnitTest.Builders;

namespace ApiClean.Tests.XUnitTest.Cases.Application.Comment.Delete
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("ApiClean.Tests.TestCaseOrdering.PriorityOrderer", "ApiClean.Tests")]
    public class CommentDeleteUseCaseTests
    {
        private readonly ICommentDeleteUseCase commentDeleteUseCase;
        private readonly CommentPresenter presenter;
        private readonly ICommentWriteOnlyRepository commentWriteOnlyRepository;
        private static Guid CommentId;

        public CommentDeleteUseCaseTests(ICommentDeleteUseCase commentDeleteUseCase, CommentPresenter presenter, ICommentWriteOnlyRepository commentWriteOnlyRepository)
        {
            this.commentDeleteUseCase = commentDeleteUseCase;
            this.presenter = presenter;
            this.commentWriteOnlyRepository = commentWriteOnlyRepository;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddSomeCustomer()
        {
            var model = CommentBuilder.New().Build();
            CommentId = model.Id;
            var ret = commentWriteOnlyRepository.Add(model);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldDeleteCustomer()
        {
            var request = new CommentDeleteRequest(CommentId);
            commentDeleteUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldDeleteCustomerAndReturnError()
        {
            var request = new CommentDeleteRequest(Guid.NewGuid());
            commentDeleteUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
