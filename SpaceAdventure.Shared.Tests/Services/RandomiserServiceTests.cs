using AutoFixture;
using FluentAssertions;
using SpaceAdventure.Shared.Services;
using SpaceAdventure.Shared.Services.Interfaces;
using System;
using Xunit;

namespace SpaceAdventure.Shared.Tests.Services
{
    public class RandomiserServiceTests
    {
        private readonly IRandomiserService _randomiserService;
        private readonly Fixture _fixture;

        public RandomiserServiceTests()
        {
            _randomiserService = new RandomiserService();
            _fixture = new Fixture();
        }

        [Fact]
        public void GetRandomInt_ShouldReturnIntBetweenMinAndMax()
        {
            // Arrange
            int min = _fixture.Create<int>();
            int max = min + _fixture.Create<int>();

            // Act
            int result = _randomiserService.GetRandomInt(min, max);

            // Assert
            result.Should().BeInRange(min, max);
        }

        [Fact]
        public void GetRandomInt_ShouldReturnSameResultForSameSeed()
        {
            // Arrange
            int min = _fixture.Create<int>();
            int max = min + _fixture.Create<int>();
            int seed = _fixture.Create<int>();
            var random1 = new Random(seed);
            var random2 = new Random(seed);

            // Act
            int result1 = random1.Next(min, max);
            int result2 = random2.Next(min, max);

            // Assert
            result1.Should().Be(result2);
        }
    }
}