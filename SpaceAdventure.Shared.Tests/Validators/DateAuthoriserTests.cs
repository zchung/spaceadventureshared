using FluentAssertions;
using NodaTime;
using NodaTime.Extensions;
using NSubstitute;
using SpaceAdventure.Shared.Validators;
using System;
using Xunit;

namespace SpaceAdventure.Shared.Tests.Validators
{
    public class DateAuthoriserTests
    {
        private readonly IClock _clock;
        private readonly DateAuthoriser _sut;

        public DateAuthoriserTests()
        {
            _clock = Substitute.For<IClock>();
            _sut = new DateAuthoriser(_clock);
        }

        [Fact]
        public void AuthoriseHeader_ShouldReturnTrue_WhenAuthCodeIsValid()
        {
            // Arrange
            const string authCode = "2023/04/07";
            var dateTimeUtc = new DateTime(2023, 4, 7, 0, 0, 0, DateTimeKind.Utc);
            var instant = dateTimeUtc.ToInstant();
            _clock.GetCurrentInstant().Returns(instant);

            // Act
            var result = _sut.AuthoriseHeader(authCode);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void AuthoriseHeader_ShouldReturnFalse_WhenAuthCodeIsNull()
        {
            // Arrange
            const string authCode = null;

            // Act
            var result = _sut.AuthoriseHeader(authCode);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void AuthoriseHeader_ShouldReturnFalse_WhenAuthCodeIsEmpty()
        {
            // Arrange
            const string authCode = "";

            // Act
            var result = _sut.AuthoriseHeader(authCode);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void AuthoriseHeader_ShouldReturnFalse_WhenAuthCodeIsInvalid()
        {
            // Arrange
            const string authCode = "invalid";

            // Act
            var result = _sut.AuthoriseHeader(authCode);

            // Assert
            result.Should().BeFalse();
        }
    }
}