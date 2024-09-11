using System;

namespace Hole3
{
    public class Money
    {
        public readonly int value;
        public readonly String currency;

        public Money(int value, String currency)
        {
            this.value = value;
            this.currency = currency;
        }

        public Money Plus(Money next)
        {
            if (!next.currency.Equals(currency))
            {
                throw new Incalculable();
            }

            return new Money(value + next.value, next.currency);
        }
    }
}