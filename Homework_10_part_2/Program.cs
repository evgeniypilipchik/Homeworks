namespace Homework_10_part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OnlineStore onlineStore = new OnlineStore
            ([
                new Order("Конфетница", 1001),
                new Order("Зеркало", 1002),
                new Order("Сервиз", 1003),
                new Order("Ваза", 1004)
            ]);

            Console.WriteLine("Выберите товар из списка:");

            for (int i = 0; i < onlineStore.Orders.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {onlineStore.Orders[i].OrderName}");
            }

            onlineStore.OnOrderProcessed += onlineStore.NotifyClient;
            onlineStore.OnOrderProcessed += onlineStore.NotifyManager;

            Console.WriteLine();
            int productType = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            onlineStore.ProcessOrder(onlineStore.Orders[productType - 1].OrderId);
        }
    }
}