namespace Homework_11
{
    internal class ComparablePair<T1, T2> : IComparable<ComparablePair<T1, T2>> where T1 : IComparable<T1> where T2 : IComparable<T2>
    {
        public T1 T1Value { get; }

        public T2 T2Value { get; }

        public ComparablePair(T1 T1Value, T2 T2Value)
        {
            this.T1Value = T1Value;
            this.T2Value = T2Value;
        }

        public static ComparablePair<T1, T2> Max(ComparablePair<T1, T2> pair1, ComparablePair<T1, T2> pair2)
        {
            return pair1.CompareTo(pair2) > 0 ? pair1 : pair2;
        }

        public int CompareTo(ComparablePair<T1, T2> other)
        {
            var firstComparision = T1Value.CompareTo(other.T1Value);

            if (firstComparision != 0)
            {
                return firstComparision;
            }
            else
            {
                return T2Value.CompareTo(other.T2Value);
            }
        }
    }
}
