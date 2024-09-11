namespace Hole2
{
    public class Money<A, B>
    {
        public readonly int first;
        public readonly string second;

        public Money(int value, string currency)
        {
            this.first = value;
            this.second = currency;
        }
    }
}