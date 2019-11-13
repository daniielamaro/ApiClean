using ApiClean.Application.UseCases.Comment.Save;
using ApiClean.Application.UseCases.Comment.Save.Handlers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace XUnitTest.Cases.Application.Comment.Save.Handler
{
    [UseAutofacTestFramework]
    public class SaveHandlerTests
    {
        private readonly SaveHandler saveHandler;

        public SaveHandlerTests(SaveHandler saveHandler)
        {
            this.saveHandler = saveHandler;
        }

        [Fact]
        public void ShouldSave()
        {
            var request = new CommentSaveRequest(ApiClean.Tests.XUnitTest.Builders.UserBuilder.New().Build(), "Comment", ApiClean.Tests.XUnitTest.Builders.PublicationBuilder.New().Id);
            Action act = () => saveHandler.ProcessRequest(request);
            act.Should().NotThrow<ArgumentException>();
        }
    }
}
