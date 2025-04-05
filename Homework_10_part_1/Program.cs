namespace Homework_10_part_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 53, 22, 84, 2, 7, 10 };
            Console.WriteLine(string.Join(", ", numbers));

            Console.WriteLine("\n" +
                "Выберите критерий фильтрации чисел:\n" +
                "1. Оставить чётные числа\n" +
                "2. Оставить нечётные числа\n" +
                "3. Оставить числа больше 10\n" +
                "4. Оставить числа меньше 10 включительно\n");

            string filterType = Console.ReadLine();
            Console.WriteLine();

            Predicate<int> filter;

            switch (filterType)
            {
                case "1":
                    filter = n => n % 2 == 1;
                    break;
                case "2":
                    filter = n => n % 2 == 0;
                    break;
                case "3":
                    filter = n => n <= 10;
                    break;
                case "4":
                    filter = n => n > 10;
                    break;
                default:
                    filter = n => false;
                    break;
            }

            Filter(filter, numbers);
            Console.WriteLine(string.Join(", ", numbers));
        }

        static void Filter(Predicate<int> filter, List<int> numbers)
        {
            numbers.RemoveAll(n => filter(n));
        }
    }
}
