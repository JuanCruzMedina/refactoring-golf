using System;
using Xunit;

namespace Hole4.Tests
{
    public class TakeHomeCalculatorTest
    {
        [Fact]
        public void CanCalculateTax()
        {
            int first = new TakeHomeCalculator(10).NetAmount(Money.CreateInstance(40, "GBP"),
                Money.CreateInstance(50, "GBP"),
                Money.CreateInstance(60, "GBP")).value;
            Assert.Equal(135, first);
        }

        [Fact]
        public void CannotSumDifferentCurrencies()
        {
            Assert.Throws<Incalculable>(() => new TakeHomeCalculator(10).NetAmount(Money.CreateInstance(4, "GBP"), Money.CreateInstance(5, "USD")));
        }
    }
}