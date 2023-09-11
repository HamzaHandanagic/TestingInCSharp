using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Tests.Unit
{
    public class CalculatorTests
    {
        /// <summary>
        /// Basic test without assertion.
        /// </summary>
        [Fact]
        public void Test()
        {
            var result = new Calculator().Add(1, 2);
            if (result != 3)
            {
                throw new Exception("Result wasn't 3");
            }
        }

        /// <summary>
        /// Proper naming of a test using <method_name>
        /// </summary>
        [Fact]
        public void Add_ShouldAddTwoNumbers_WhenBothOfThemArePositiveIntegers_1()
        {
            var result = new Calculator().Add(1, 2);
            if (result != 3)
            {
                throw new Exception("Result wasn't 3");
            }
        }

        /// <summary>
        /// System under test
        /// </summary>
        [Fact]
        public void Add_ShouldAddTwoNumbers_WhenBothOfThemArePositiveIntegers_2()
        {
            var sut = new Calculator();

            var result = sut.Add(1, 2);
            if (result != 3)
            {
                throw new Exception("Result wasn't 3");
            }
        }

        /// <summary>
        /// SUT and xUnit Assert
        /// </summary>
        [Fact]
        public void Add_ShouldAddTwoNumbers_WhenBothOfThemArePositiveIntegers_3()
        {
            var sut = new Calculator();

            var result = sut.Add(1, 2);

            Assert.Equal(3, result);
        }

        /// <summary>
        /// SUT with FluentAssertions
        /// </summary>
        [Fact]
        public void Add_ShouldAddTwoNumbers_WhenBothOfThemArePositiveIntegers_4()
        {
            var sut = new Calculator();

            var result = sut.Add(1, 2);

            result.Should().Be(3);
        }

        /// <summary>
        /// AAA with FluentAssertions
        /// </summary>
        [Fact]
        public void Add_ShouldAddTwoNumbers_WhenBothOfThemArePositiveIntegers_5()
        {
            // Arrange
            var sut = new Calculator();

            // Act
            var result = sut.Add(1, 2);

            // Assert
            result.Should().Be(3);
        }
    }
}
