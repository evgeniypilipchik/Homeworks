namespace Homework_10_part_2
{
    internal class OnlineStore
    {

        public string OrderName;
        public int OrderId;

        public OnlineStore(string name, int id)
        {
            OrderName = name;
            OrderId = id;
        }

        public delegate void OrderHandler(int orderId);
        public event OrderHandler? OnOrderProcessed;

        public void ProcessOrder(int orderId)
        {
            Console.WriteLine($"Ваш заказ {orderId}\n");
            OnOrderProcessed?.Invoke(orderId);
        }
    }
}
