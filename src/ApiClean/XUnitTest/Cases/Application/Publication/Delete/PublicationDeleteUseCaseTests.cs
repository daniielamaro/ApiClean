using ApiClean.Application.Repositories;
using Application.UseCases.Publication.Delete;
using Application.UseCases.Topic.Delete;
using Application.UseCases.User.Delete;
using DemoCleanArchitecture.Tests.TestCaseOrdering;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;
using XUnitTest.Builders;

namespace XUnitTest.Cases.Application.Publication.Delete
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("ApiClean.Tests.TestCaseOrdering.PriorityOrderer", "ApiClean.Tests")]
    public class PublicationDeleteUseCaseTests
    {
        private readonly IPublicationDeleteUseCase publicationDeleteUseCase;
        private readonly PublicationPresenter presenter;
        private readonly IPublicationWriteOnlyRepository publicationWriteOnlyRepository;
        private static Guid UserId;

        public PublicationDeleteUseCaseTests(IPublicationDeleteUseCase publicationDeleteUseCase, PublicationPresenter presenter, IPublicationWriteOnlyRepository publicationWriteOnlyRepository)
        {
            this.publicationDeleteUseCase = publicationDeleteUseCase;
            this.presenter = presenter;
            this.publicationWriteOnlyRepository = publicationWriteOnlyRepository;
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldAddSomeCustomer()
        {
            var model = PublicationBuilder.New().Build();
            UserId = model.Id;
            var ret = publicationWriteOnlyRepository.Add(model);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldDeleteCustomer()
        {
            var request = new PublicationDeleteRequest(UserId);
            publicationDeleteUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldDeleteCustomerAndReturnError()
        {
            var request = new PublicationDeleteRequest(Guid.NewGuid());
            publicationDeleteUseCase.Execute(request);
            presenter.ViewModel.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
