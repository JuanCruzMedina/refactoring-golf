using System;
using System.Collections.Generic;
using System.Linq;

namespace Hole2
{
    public class TakeHomeCalculator
    {
        private readonly int percent;

        public TakeHomeCalculator(int percent)
        {
            this.percent = percent;
        }

        public Money<int, String> NetAmount(Money<int, String> first, params Money<int, String>[] rest)
        {
            List<Money<int, String>> pairs = rest.ToList();

            Money<int, String> total = first;

            foreach (Money<int, String> next in pairs)
            {
                if (!next.Currency.Equals(total.Currency))
                {
                    throw new Incalculable();
                }
            }

            foreach (Money<int, String> next in pairs)
            {
                total = new Money<int, String>(total.Value + next.Value, next.Currency);
            }

            Double amount = total.Value * (percent / 100d);
            Money<int, String> tax = new Money<int, String>(Convert.ToInt32(amount), first.Currency);

            if (!total.Currency.Equals(tax.Currency))
            {
                throw new Incalculable();
            }

            return new Money<int, String>(total.Value - tax.Value, first.Currency);
        }
    }
}