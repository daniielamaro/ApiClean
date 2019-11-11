using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XUnitTest.Builders;

namespace XUnitTest.Cases.Domain.Publication
{
    public class PublicationTests
    {
        #region Create Tests
        [Fact]
        public void ShouldCreateDomain()
        {
            var publication = PublicationBuilder.New().Build();
            publication.IsValid.Should().BeTrue();
        }
        #endregion

        #region Null and Empty Tests
        [Fact]
        public void ShouldNotCreateDomainWithPublicationIdNullOrEmpty()
        {
            var publication = PublicationBuilder.New().WithId(new Guid()).Build();
            publication.IsValid.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotCreateDomainWithAuthorIdOfPublicationNullOrEmpty()
        {
            var author = UserBuilder.New().WithId(new Guid()).Build();
            var publication = PublicationBuilder.New().WithAutor(author).Build();
            publication.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateDomainWithPublicationTitleNullOrEmpty(string title)
        {
            var publication = PublicationBuilder.New().WithTitle(title).Build();
            publication.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateDomainWithPublicationContentNullOrEmpty(string content)
        {
            var publication = PublicationBuilder.New().WithContent(content).Build();
            publication.IsValid.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotCreateDomainWithTopicIdOfPublicationNullOrEmpty()
        {
            var topic = TopicBuilder.New().WithId(new Guid()).Build();
            var publication = PublicationBuilder.New().WithTopic(topic).Build();
            publication.IsValid.Should().BeFalse();
        }
        #endregion
    }
}
