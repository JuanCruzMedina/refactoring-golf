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
                if (!next.second.Equals(total.second))
                {
                    throw new Incalculable();
                }
            }

            foreach (Money<int, String> next in pairs)
            {
                total = new Money<int, String>(total.first + next.first, next.second);
            }

            Double amount = total.first * (percent / 100d);
            Money<int, String> tax = new Money<int, String>(Convert.ToInt32(amount), first.second);

            if (!total.second.Equals(tax.second))
            {
                throw new Incalculable();
            }

            return new Money<int, String>(total.first - tax.first, first.second);
        }
    }
}