using AutoFixture;
using FluentAssertions;
using SpaceAdventure.Shared.Models;
using SpaceAdventure.Shared.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SpaceAdventure.Shared.Tests.Models
{
    public class ResultTests
    {
        private readonly Fixture _fixture;

        public ResultTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void MapResult_ShouldCopyResultData()
        {
            // Arrange
            var originalResult = Result.GetFailedResult("error1");
            var newResult = Result.GetFailedResult("error2");

            // Act
            newResult.MapResult(originalResult);

            // Assert
            newResult.ResultType.Should().Be(originalResult.ResultType);
            newResult.Messages.Should().BeEquivalentTo(new List<string>
            {
                "error1",
                "error2"
            });
        }

        [Fact]
        public void GetSuccessResult_ShouldCreateResultWithSuccessType()
        {
            // Arrange
            var expectedResult = new Result(ResultType.Success);

            // Act
            var result = Result.GetSuccessResult();

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void GetFailedResult_ShouldCreateResultWithErrorMessage()
        {
            // Arrange
            var message = _fixture.Create<string>();
            var expectedResult = new Result(ResultType.Error)
            {
                Messages = new List<string> { message }
            };

            // Act
            var result = Result.GetFailedResult(message);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void GetFailedResult_ShouldCreateResultWithMultipleErrorMessages()
        {
            // Arrange
            var messages = _fixture.CreateMany<string>().ToList();
            var expectedResult = new Result(ResultType.Error)
            {
                Messages = new List<string>(messages)
            };

            // Act
            var result = Result.GetFailedResult(messages);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }

    public class ResultOfTTests
    {
        private readonly Fixture _fixture;

        public ResultOfTTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void GetSuccessResult_ShouldCreateResultWithSuccessTypeAndData()
        {
            // Arrange
            var data = _fixture.Create<int>();
            var expectedResult = new Result<int>(ResultType.Success)
            {
                Data = data
            };

            // Act
            var result = Result<int>.GetSuccessResult(data);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void GetFailedResult_ShouldCreateResultWithErrorMessage()
        {
            // Arrange
            var message = _fixture.Create<string>();
            var expectedResult = new Result<int>(ResultType.Error)
            {
                Messages = new List<string> { message }
            };

            // Act
            var result = Result<int>.GetFailedResult(message);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void GetFailedResult_ShouldCreateResultWithMultipleErrorMessages()
        {
            // Arrange
            var messages = _fixture.CreateMany<string>().ToList();
            var expectedResult = new Result<int>(ResultType.Error)
            {
                Messages = new List<string>(messages)
            };

            // Act
            var result = Result<int>.GetFailedResult(messages);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void MapResult_ShouldCopyResultData()
        {
            // Arrange
            var originalResult = Result<int>.GetFailedResult("error1");
            var newResult = Result<int>.GetFailedResult("error2");

            // Act
            newResult.MapResult(originalResult);

            // Assert
            newResult.ResultType.Should().Be(originalResult.ResultType);
            newResult.Messages.Should().BeEquivalentTo(new List<string>
            {
                "error1",
                "error2"
            });
        }
    }
}