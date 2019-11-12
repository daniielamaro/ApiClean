using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ApiClean.Tests.XUnitTest.Builders;
using FluentAssertions;

namespace ApiClean.Tests.XUnitTest.Cases.Domain.User
{
    public class UserTests
    {
        #region Create Tests
        [Fact]
        public void ShouldCreateDomain()
        {
            var user = UserBuilder.New().Build();
            user.IsValid.Should().BeTrue();
        }
        #endregion

        #region Null and Empty Tests
        [Fact]
        public void ShouldNotCreateDomainWithUserIdNullOrEmpty()
        {
            var user = UserBuilder.New().WithId(new Guid()).Build();
            user.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateDomainWithUserNameNullOrEmpty(string name)
        {
            var user = UserBuilder.New().WithName(name).Build();
            user.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateDomainWithUserEmailNullOrEmpty(string email)
        {
            var user = UserBuilder.New().WithEmail(email).Build();
            user.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNotCreateDomainWithUserPasswordNullOrEmpty(string password)
        {
            var user = UserBuilder.New().WithPassword(password).Build();
            user.IsValid.Should().BeFalse();
        }
        #endregion

        #region Create user name with invalid characters tests
        [Theory]
        [InlineData("User 2")]
        [InlineData("User #")]
        public void ShouldNotCreateDomainWithUserNameContainsInvalidCharacters(string name)
        {
            var user = UserBuilder.New().WithName(name).Build();

            user.IsValid.Should().BeFalse();
        }
        #endregion

        #region Create user name with length bigger than 150
        [Fact]
        public void ShouldNotCreateDomainWithUserNameLengthBiggerThan150()
        {
            var user = UserBuilder.New()
                .WithName("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed facilisis magna ut enim pretium vestibulum. Nullam pretium condimentum mauris, tincidunt consequat eros finibus ac. Maecenas commodo metus.")
                .Build();

            user.IsValid.Should().BeFalse();
        }
        #endregion

        #region Create user email invalid Tests
        [Fact]
        public void ShouldNotCreateDomainWithUserEmailInvalid()
        {
            var user = UserBuilder.New().WithEmail("useremail.com").Build();

            user.IsValid.Should().BeFalse();
        }
        #endregion

        #region Create user password with length less than 8 Tests
        [Fact]
        public void ShouldNotCreateDomainWithUserPasswordLessThan8()
        {
            var user = UserBuilder.New().WithPassword("1234").Build();

            user.IsValid.Should().BeFalse();
        }
        #endregion
    }
}
