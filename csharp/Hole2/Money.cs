namespace Hole2
{
    public class Money<A, B>
    {
        public readonly int Value;
        public readonly string Currency;

        public Money(int value, string currency)
        {
            this.Value = value;
            this.Currency = currency;
        }
    }
}