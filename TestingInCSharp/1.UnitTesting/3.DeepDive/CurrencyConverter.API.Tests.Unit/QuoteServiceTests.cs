using CurrencyConverter.API.Database;
using CurrencyConverter.API.Models;
using CurrencyConverter.API.Repositories;
using CurrencyConverter.API.Services;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using NSubstitute;
using CurrencyConverter.API.Exceptions;
using NSubstitute.ReturnsExtensions;

namespace CurrencyConverter.API.Tests.Unit
{

    public class QuoteServiceTests
    {
        private readonly QuoteService _sut;
        private readonly IRatesRepository _ratesRepository = Substitute.For<IRatesRepository>();
        private readonly ILogger<QuoteService> _logger = new NullLogger<QuoteService>();

        public QuoteServiceTests()
        {
            _sut = new(_ratesRepository, _logger);
        }

        [Fact]
        public async Task GetQuoteAsync_ShouldReturnQuote_WhenCurrenciesAreValid()
        {
            // Arrange
            var fromCurrency = "BAM";
            var toCurrency = "USD";
            var amount = 100;

            var expectedRate = new CurrencyRate
            {
                FromCurrency = fromCurrency,
                ToCurrency = toCurrency,
                Rate = 1.82m
            };

            //  In order to make the GetRateAsync method of the IRatesRepository to return that rate
            //  all we need to do is invoke it and chain the Returns method with the expected rate.
            _ratesRepository.GetRateAsync(fromCurrency, toCurrency).Returns(expectedRate);

            var expectedQuote = new ConversionQuote
            {
                BaseCurrency = fromCurrency,
                QuoteCurrency = toCurrency,
                BaseAmount = 100,
                QuoteAmount = 182
            };

            // Act
            var quote = await _sut.GetQuoteAsync(fromCurrency, toCurrency, amount);

            // Assert
            quote!.Should().BeEquivalentTo(expectedQuote);
        }

        [Fact]
        public async Task GetQuoteAsync_ShouldReturnNull_WhenCurrenciesAreNotSupported()
        {
            // Arrange
            var fromCurrency = "DKK";
            var toCurrency = "USD";
            var amount = 100;

            _ratesRepository.GetRateAsync(fromCurrency, toCurrency).ReturnsNull();

            // Act
            var quote = await _sut.GetQuoteAsync(fromCurrency, toCurrency, amount);

            // Assert
            quote.Should().BeNull();
        }

        [Fact]
        public async Task GetQuoteAsync_ShouldThrowNegativeAmountException_WhenAmountIsNegative()
        {
            // Arrange
            var fromCurrency = "USD";
            var toCurrency = "GBP";
            var amount = 0;

            // Act
            // The use of an action allows you to defer the execution of until the assertion phase. 
            // Basically we are going to store a method in a variable => delegates
            var resultAction = () => _sut.GetQuoteAsync(fromCurrency, toCurrency, amount);

            // Assert
            await resultAction.Should()
                .ThrowAsync<NegativeAmountException>()
                .WithMessage("You can only convert a positive amount of money");
        }

        [Fact]
        public async Task GetQuoteAsync_ShouldThrowSameCurrencyException_WhenSameCurrenciesAreUsed()
        {
            // Arrange
            var fromCurrency = "BAM";
            var toCurrency = "BAM";
            var amount = 1m;

            // Act
            var resultAction = () => _sut.GetQuoteAsync(fromCurrency, toCurrency, amount);

            // Assert
            await resultAction.Should()
                .ThrowAsync<SameCurrencyException>()
                .WithMessage($"You cannot convert currency {fromCurrency} to itself");
        }

    }
}
