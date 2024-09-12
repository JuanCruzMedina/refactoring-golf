using System;
using System.Collections.Generic;
using System.Linq;

namespace Hole5
{
    public class TaxRate
    {
        private readonly int percent;

        public TaxRate(int percent)
        {
            this.percent = percent;
        }

        public Money Apply(Money total)
        {
            Double amount = total.value * (percent / 100d);
            return Money.Create(Convert.ToInt32(amount), total.currency);
        }
    }

    public class TakeHomeCalculator
    {
        private readonly TaxRate taxRate;

        public TakeHomeCalculator(int percent)
        {
            taxRate = new TaxRate(percent);
        }

        public Money NetAmount(Money first, params Money[] rest)
        {
            List<Money> monies = rest.ToList();

            Money total = first;

            foreach (Money next in monies)
            {
                total = total.Plus(next);
            }

            var tax = taxRate.Apply(total);
            return total.Minus(tax);
        }
    }
}