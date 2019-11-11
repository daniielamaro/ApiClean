using Application.UseCases.Publication.GetAll;
using Application.UseCases.User.GetAll;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.UseCases.User;
using Xunit;

namespace XUnitTest.Cases.Application.Publication.GetAll
{
    public class PublicationGetAllUseCaseTests
    {
        private readonly IPublicationGetAllUseCase publicationGetAllUseCase;
        private readonly PublicationPresenter presenter;

        public PublicationGetAllUseCaseTests(IPublicationGetAllUseCase publicationGetAllUseCase, PublicationPresenter presenter)
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
