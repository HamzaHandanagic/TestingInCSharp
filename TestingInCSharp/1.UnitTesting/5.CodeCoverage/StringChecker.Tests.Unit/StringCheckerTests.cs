using Xunit;

namespace StringChecker.Tests.Unit
{
    public class StringCheckerTests
    {
        [Fact]
        public void IsStringLong_ShouldReturnTrue_WhenStringIsLongerThan6Characters()
        {
            // Arrange
            var sut = new StringChecker();
            var input = "skafiskafnjak";

            // Act
            var result = sut.IsStringLong(input);

            // Assert
            Assert.True(result);
        }
    }
}