namespace Hole2
{
    public class Money<A, B>
    {
        public readonly A first;
        public readonly B second;

        public Money(A first, B second)
        {
            this.first = first;
            this.second = second;
        }
    }
}