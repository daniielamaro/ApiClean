using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XUnitTest.Builders;

namespace XUnitTest.Cases.Domain.Topic
{
    public class TopicTests
    {
        #region Create Tests
        [Fact]
        public void ShouldCreateDomain()
        {
            var user = TopicBuilder.New().Build();
            user.IsValid.Should().BeTrue();
        }
        #endregion

        #region Null and Empty Tests
        [Fact]
        public void ShouldNotCreateDomainWithTopicIdNullOrEmpty()
        {
            var topic = TopicBuilder.New().WithId(new Guid()).Build();
            topic.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateDomainWithTopicNameNullOrEmpty(string name)
        {
            var topic = TopicBuilder.New().WithName(name).Build();
            topic.IsValid.Should().BeFalse();
        }
        #endregion
    }
}
