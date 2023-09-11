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
        #region basic_tests
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

        #endregion

        #region parameterized_tests
        /// <summary>
        /// Multiple test cases using InlineData.
        /// </summary>
        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(5, 5, 0)]
        [InlineData(3, 5, -2)]
        public void Subtract_ShouldSubtractTwoNumbers_WhenTheNumbersAreIntegers(int a, int b, int final)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Subtract(a, b);

            // Assert
            result.Should().Be(final);
        }
        public static IEnumerable<object[]> SubtractData => new List<object[]>
        {
            new object[] { 5, 3, 2 },
            new object[] { 5, 5, 0 },
            new object[] { 3, 5, -2 }
        };

        /// <summary>
        /// Using MemberData Attribute
        /// </summary>
        [Theory]
        [MemberData(nameof(SubtractData))]
        public void Subtract_ShouldSubtractTwoNumbers_WhenTheNumbersAreIntegers2(int a, int b, int final)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Subtract(a, b);

            // Assert
            result.Should().Be(final);
        }

        /// <summary>
        /// Using ClassData Attribute
        /// </summary>
        [Theory]
        [ClassData(typeof(SubstractData))]
        public void Subtract_ShouldSubtractTwoNumbers_WhenTheNumbersAreIntegers3(int a, int b, int final) 
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Subtract(a, b);

            // Assert
            result.Should().Be(final);
        }

        #endregion
    }
}
