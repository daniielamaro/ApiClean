using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ApiClean.Tests.XUnitTest.Builders;

namespace ApiClean.Tests.XUnitTest.Cases.Domain.Comment
{
    public class CommentTests
    {
        #region Create Tests
        [Fact]
        public void ShouldCreateDomain()
        {
            var comment = CommentBuilder.New().Build();
            comment.IsValid.Should().BeTrue();
        }
        #endregion

        #region Null and Empty Tests
        [Fact]
        public void ShouldNotCreateDomainWithCommentIdNullOrEmpty()
        {
            var comment = CommentBuilder.New().WithId(new Guid()).Build();
            comment.IsValid.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotCreateDomainWithCommentAuthorNullOrEmpty()
        {
            var author = UserBuilder.New().WithId(new Guid()).Build();
            var comment = CommentBuilder.New().WithAutor(author).Build();
            comment.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateDomainWithCommentContentNullOrEmpty(string content)
        {
            var comment = CommentBuilder.New().WithContent(content).Build();
            comment.IsValid.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotCreateDomainWithCommentPublicationIdNullOrEmpty()
        {
            var comment = CommentBuilder.New().WithPublicationId(new Guid()).Build();
            comment.IsValid.Should().BeFalse();
        }
        #endregion
    }
}
