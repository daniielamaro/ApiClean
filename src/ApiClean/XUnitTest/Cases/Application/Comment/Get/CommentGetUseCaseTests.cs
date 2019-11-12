using ApiClean.Application.Repositories;
using Application.UseCases.Comment.Delete;
using Application.UseCases.Comment.Get;
using Application.UseCases.Publication.Get;
using Application.UseCases.Topic.Get;
using Application.UseCases.User.Get;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.UseCases.Comment;
using WebApi.UseCases.User;
using Xunit;
using Xunit.Frameworks.Autofac;
using ApiClean.Tests.XUnitTest.Builders;

namespace ApiClean.Tests.XUnitTest.Cases.Application.Comment.Get
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("ApiClean.Tests.TestCaseOrdering.PriorityOrderer", "ApiClean.Tests")]
    public class CommentGetUseCaseTests
    {
        public class CustomerGetUseCaseTests
        {
            private readonly ICommentGetUseCase commentGetUseCase;
            private readonly CommentPresenter presenter;
            private readonly ICommentWriteOnlyRepository commentWriteOnlyRepository;
            private static Guid CommentId;

            public CustomerGetUseCaseTests(ICommentGetUseCase commentGetUseCase, CommentPresenter presenter, ICommentWriteOnlyRepository commentWriteOnlyRepository)
            {
                this.commentGetUseCase = commentGetUseCase;
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
            public void ShouldGetCustomerById()
            {
                var request = new CommentGetRequest(CommentId);
                commentGetUseCase.Execute(request);
                presenter.ViewModel.Should().BeOfType<OkObjectResult>();
            }

            [Fact]
            [TestPriority(2)]
            public void ShouldNotGetCustomerByIdAndReturnNotFound()
            {
                var request = new CommentGetRequest(Guid.NewGuid());
                commentGetUseCase.Execute(request);
                presenter.ViewModel.Should().BeOfType<NotFoundObjectResult>();
            }
        }
    }
}
