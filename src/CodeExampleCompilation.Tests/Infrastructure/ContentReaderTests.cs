using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using CodeExampleCompilation.Infrastructure;
using CodeExampleCompilation.Infrastructure.IO;
using CodeExampleCompilation.Application;
using CodeExampleCompilation.Domain;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.NUnit3;
using Moq;
using FluentAssertions;

namespace CodeExampleCompilation.Tests.Infrastructure
{
    public class ContentReaderTests
    {
        private IFixture _fixture;
        private Mock<IDirectory> _directory = new Mock<IDirectory>();
        private Mock<IFile> _file = new Mock<IFile>();
       
        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture()
                 .Customize(new AutoMoqCustomization());

            _file = _fixture.Freeze<Mock<IFile>>();
            _directory = _fixture.Freeze<Mock<IDirectory>>();
        }

        [Test]        
        public async Task Should_Deserialize_Content()
        {
            _directory.Setup(x => x.EnumerateDirectories(It.IsAny<string>()))
                .Returns(new List<string>
                {
                    "test"
                });

            _file.Setup(x => x.ReadAllTextAsync($"test/{Constants.ContentFileName}"))
                .ReturnsAsync("{ \"Header\": \"Test\", \"Content\": \"VGhpcyBpcyBzb21lIHRlc3QgY29udGVudA==\" }");

            var contentReader = _fixture.Create<ContentReader>();
            var content = await contentReader.Read("test");                

            content.Should().NotBeNull();
            content.First().FilePath.Should().Be("test");
            content.First().ContentItem.Header.Should().Be("Test");
            content.First().ContentItem.Content.Should().Be("VGhpcyBpcyBzb21lIHRlc3QgY29udGVudA==");
        }

        [Test]        
        public async Task Should_Deserialize_On_Empty_Content()
        {
            _directory.Setup(x => x.EnumerateDirectories(It.IsAny<string>()))
                .Returns(new List<string>
                {
                    "test"
                });

            _file.Setup(x => x.ReadAllTextAsync($"test/{Constants.ContentFileName}"))
                .ReturnsAsync("{ \"Header\": \"Test\", \"Content\": \"\" }");

            var contentReader = _fixture.Create<ContentReader>();
            var content = await contentReader.Read("test");

            Action act = () => { var x = content.First().ContentItem.Content; };
            act.Should().NotThrow<FormatException>();
        }
    }
}