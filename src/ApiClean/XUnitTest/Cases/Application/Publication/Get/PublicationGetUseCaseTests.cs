using ApiClean.Application.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.UseCases.Publication;
using Xunit;
using Xunit.Frameworks.Autofac;
using ApiClean.Tests.XUnitTest.Builders;
using ApiClean.Application.UseCases.Publication.Get;
using ApiClean.Tests.TestCaseOrdering;

namespace ApiClean.Tests.XUnitTest.Cases.Application.Publication.Get
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("ApiClean.Tests.TestCaseOrdering.PriorityOrderer", "ApiClean.Tests")]
    public class PublicationGetUseCaseTests
    {
        private readonly IPublicationGetUseCase publicationGetUseCase;
        private readonly PublicationPresenter presenter;
        private readonly IPublicationWriteOnlyRepository publicationWriteOnlyRepository;
        private static Guid PublicationId;

        public PublicationGetUseCaseTests(IPublicationGetUseCase publicationGetUseCase, PublicationPresenter presenter, IPublicationWriteOnlyRepository publicationWriteOnlyRepository)
        {
            this.publicationGetUseCase = publicationGetUseCase;
            this.presenter = presenter;
            this.publicationWriteOnlyRepository = publicationWriteOnlyRepository;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddSomeCustomer()
        {
            var model = PublicationBuilder.New().Build();
            PublicationId = model.Id;
            var ret = publicationWriteOnlyRepository.Add(model);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldGetCustomerById()
        {
            var request = new PublicationGetRequest(PublicationId);
            publicationGetUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldNotGetCustomerByIdAndReturnNotFound()
        {
            var request = new PublicationGetRequest(Guid.NewGuid());
            publicationGetUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<NotFoundObjectResult>();
        }
    }
}

