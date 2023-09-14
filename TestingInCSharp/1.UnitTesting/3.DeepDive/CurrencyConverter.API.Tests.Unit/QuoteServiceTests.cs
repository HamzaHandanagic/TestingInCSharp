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

namespace CurrencyConverter.API.Tests.Unit
{

    public class QuoteServiceTests
    {
        private readonly QuoteService _sut;
        private readonly IRatesRepository _ratesRepository = new RatesRepository(new NpgsqlConnectionFactory("Server=localhost;Port=5432;Database=test_workshop;User ID=postgres;Password=test;"));
        private readonly ILogger<QuoteService> _logger = new NullLogger<QuoteService>();

        public QuoteServiceTests()
        {
            _sut = new(_ratesRepository, _logger);
        }

        [Fact]
        public async Task GetQuoteAsync_ReturnsQuote_WhenCurrenciesAreValid()
        {
            // Arrange
            var fromCurrency = "BAM";
            var toCurrency = "USD";
            var amount = 100;

            var expectedQuote = new ConversionQuote
            {
                BaseCurrency = fromCurrency,
                QuoteCurrency = toCurrency,
                BaseAmount = amount,
                QuoteAmount = 182
            };

            // Act
            var quote = await _sut.GetQuoteAsync(fromCurrency, toCurrency, amount);

            // Assert
            quote!.Should().BeEquivalentTo(expectedQuote);
        }

        
    }
}
