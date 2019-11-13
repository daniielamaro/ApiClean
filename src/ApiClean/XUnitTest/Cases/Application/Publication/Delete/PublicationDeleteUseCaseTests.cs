using ApiClean.Application.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.UseCases.Publication;
using Xunit;
using Xunit.Frameworks.Autofac;
using ApiClean.Tests.XUnitTest.Builders;
using ApiClean.Application.UseCases.Publication.Delete;
using ApiClean.Tests.TestCaseOrdering;

namespace ApiClean.Tests.XUnitTest.Cases.Application.Publication.Delete
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("ApiClean.Tests.TestCaseOrdering.PriorityOrderer", "ApiClean.Tests")]
    public class CommentDeleteUseCaseTests
    {
        private readonly IPublicationDeleteUseCase publicationDeleteUseCase;
        private readonly PublicationPresenter presenter;
        private readonly IPublicationWriteOnlyRepository publicationWriteOnlyRepository;
        private static Guid publicationId;

        public CommentDeleteUseCaseTests(IPublicationDeleteUseCase publicationDeleteUseCase, PublicationPresenter presenter, IPublicationWriteOnlyRepository publicationWriteOnlyRepository)
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
            publicationId = model.Id;
            var ret = publicationWriteOnlyRepository.Add(model);
            ret.Should().Be(1);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldDeleteCustomer()
        {
            var request = new PublicationDeleteRequest(publicationId);
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
