using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DateTimeEdgeCases.Tests.Unit
{
    public class GreeterServiceTests
    {
        private readonly GreeterService _sut;
        private readonly IDateTimeProvider _dateTimeProvider = NSubstitute.Substitute.For<IDateTimeProvider>();

        public GreeterServiceTests()
        {
            _sut = new(_dateTimeProvider);
        }

        [Fact]
        public void GenerateGreetTest_ShouldReturnGoodMorning_WhenItsMorning()
        {
            // Arrange
            _dateTimeProvider.Now.Returns(new DateTimeOffset(2023, 1, 1, 9, 0, 0, TimeSpan.Zero));

            // Act
            var message = _sut.GenerateGreetText();

            // Assert
            message.Should().Be("Good morning");
        }

        [Fact]
        public void GenerateGreetTest_ShouldReturnGoodAfternon_WhenItsAfternoon() 
        {
            // Arrange
            _dateTimeProvider.Now.Returns(new DateTimeOffset(2023, 1, 1, 15, 0, 0, TimeSpan.Zero));

            // Act
            var message = _sut.GenerateGreetText();

            // Assert
            message.Should().Be("Good afternoon");
        }

        [Fact]
        public void GenerateGreetTest_ShouldReturnGoodEvening_WhenItsEvening()
        {
            // Arrange
            _dateTimeProvider.Now.Returns(new DateTimeOffset(2023, 1, 1, 19, 0, 0, TimeSpan.Zero));

            // Act
            var message = _sut.GenerateGreetText();

            // Assert
            message.Should().Be("Good evening");
        }
    }
}
