using System;
using Xunit;

namespace Hole2.Tests
{
    public class TakeHomeCalculatorTest
    {
        [Fact]
        public void CanCalculateTax()
        {
            int first = new TakeHomeCalculator(10).NetAmount(new Money<int, String>(40, "GBP"),
                new Money<int, String>(50, "GBP"),
                new Money<int, String>(60, "GBP")).Value;
            Assert.Equal(135, first);
        }

        [Fact]
        public void CannotSumDifferentCurrencies()
        {
            Assert.Throws<Incalculable>(() => new TakeHomeCalculator(10).NetAmount(new
                Money<int, String>(4, "GBP"), new Money<int, String>(5, "USD")));
        }
    }
}