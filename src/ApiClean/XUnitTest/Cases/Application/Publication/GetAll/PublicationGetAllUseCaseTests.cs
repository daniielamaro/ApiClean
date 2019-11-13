using ApiClean.Application.UseCases.Publication.GetAll;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.UseCases.Publication;
using Xunit;

namespace ApiClean.Tests.XUnitTest.Cases.Application.Publication.GetAll
{
    public class CommentGetAllUseCaseTests
    {
        private readonly IPublicationGetAllUseCase publicationGetAllUseCase;
        private readonly PublicationPresenter presenter;

        public CommentGetAllUseCaseTests(IPublicationGetAllUseCase publicationGetAllUseCase, PublicationPresenter presenter)
        {
            this.publicationGetAllUseCase = publicationGetAllUseCase;
            this.presenter = presenter;
        }

        [Fact]
        public void ShouldExecute()
        {
            publicationGetAllUseCase.Execute();
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }
    }
}
