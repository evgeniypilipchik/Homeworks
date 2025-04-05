namespace Homework_10_part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<OnlineStore> products = new List<OnlineStore>()
            {
                new OnlineStore("Конфетница", 1001),
                new OnlineStore("Зеркало", 1002),
                new OnlineStore("Сервиз", 1003),
                new OnlineStore("Ваза", 1004),
            };

            Console.WriteLine("Выберите товар из списка:");

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].OrderName}");
                products[i].OnOrderProcessed += NotifyClient;
                products[i].OnOrderProcessed += NotifyManager;
            }

            Console.WriteLine();
            int productType = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            products[productType - 1].ProcessOrder(products[productType - 1].OrderId);
        }

        static void NotifyClient(int orderId) => Console.WriteLine($"Ваш заказ {orderId} готов!");

        static void NotifyManager(int orderId) => Console.WriteLine($"Заказ {orderId} обработан.");
    }
}