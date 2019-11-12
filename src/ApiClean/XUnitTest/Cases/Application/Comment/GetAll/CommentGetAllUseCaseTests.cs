﻿using Application.UseCases.Comment.GetAll;
using Application.UseCases.Publication.GetAll;
using Application.UseCases.User.GetAll;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.UseCases.Comment;
using WebApi.UseCases.User;
using Xunit;

namespace XUnitTest.Cases.Application.Comment.GetAll
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