namespace Hole2
{
    public class Money
    {
        public readonly int Value;
        public readonly string Currency;

        public Money(int value, string currency)
        {
            Value = value;
            Currency = currency;
        }
    }
}