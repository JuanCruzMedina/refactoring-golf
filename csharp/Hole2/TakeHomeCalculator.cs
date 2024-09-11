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

        public Money NetAmount(Money first, params Money[] rest)
        {
            List<Money> pairs = rest.ToList();

            Money total = first;

            foreach (Money next in pairs)
            {
                if (!next.Currency.Equals(total.Currency))
                {
                    throw new Incalculable();
                }
            }

            foreach (Money next in pairs)
            {
                total = new Money(total.Value + next.Value, next.Currency);
            }

            Double amount = total.Value * (percent / 100d);
            Money tax = new Money(Convert.ToInt32(amount), first.Currency);

            if (!total.Currency.Equals(tax.Currency))
            {
                throw new Incalculable();
            }

            return new Money(total.Value - tax.Value, first.Currency);
        }
    }
}