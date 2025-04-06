namespace Homework_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var items = new Pair<int, string>(123, "Hello");
            Console.WriteLine(String.Join(", ", items.T1Item, items.T2Item));

            var values1 = new ComparablePair<int, string>(456, "Hello");
            var values2 = new ComparablePair<int, string>(456, "Helloo");
            var maxValue =  ComparablePair<int, string>.Max(values1, values2);
            Console.WriteLine(String.Join(", ", maxValue.T1Value, maxValue.T2Value));
        }
    }
}
