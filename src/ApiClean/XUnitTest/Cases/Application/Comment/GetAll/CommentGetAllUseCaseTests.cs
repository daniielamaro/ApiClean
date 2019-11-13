using ApiClean.Application.UseCases.Comment.GetAll;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.UseCases.Comment;
using Xunit;

namespace ApiClean.Tests.XUnitTest.Cases.Application.Comment.GetAll
{
    public class CommentGetAllUseCaseTests
    {
        private readonly ICommentGetAllUseCase commentGetAllUseCase;
        private readonly CommentPresenter presenter;

        public CommentGetAllUseCaseTests(ICommentGetAllUseCase commentGetAllUseCase, CommentPresenter presenter)
        {
            this.commentGetAllUseCase = commentGetAllUseCase;
            this.presenter = presenter;
        }

        [Fact]
        public void ShouldExecute()
        {
            commentGetAllUseCase.Execute();
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }
    }
}
