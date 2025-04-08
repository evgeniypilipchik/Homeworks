namespace Homework_11
{
    public class Pair<T1, T2>
    {
        public T1 T1Item { get; }

        public T2 T2Item { get; }

        public Pair(T1 T1Item, T2 T2Item)
        {
            this.T1Item = T1Item;
            this.T2Item = T2Item;
        }
    }
}
