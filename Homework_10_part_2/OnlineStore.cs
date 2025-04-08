namespace Homework_10_part_2
{
    internal class OnlineStore
    {
        public List<Order> Orders;

        public OnlineStore(List<Order> orders)
        {
            Orders = orders;
        }

        public delegate void OrderHandler(int orderId);
        public event OrderHandler? OnOrderProcessed;

        public void ProcessOrder(int orderId)
        {
            Console.WriteLine($"Ваш заказ {orderId}\n");
            OnOrderProcessed?.Invoke(orderId);
        }

        public void NotifyClient(int orderId) => Console.WriteLine($"Ваш заказ {orderId} готов!");

        public void NotifyManager(int orderId) => Console.WriteLine($"Заказ {orderId} обработан.");
    }
}
