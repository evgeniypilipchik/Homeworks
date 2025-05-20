using System.Text.Json;

namespace Homework_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product()
            {
                Id = 1,
                Name = "product1",
                Price = 7.99m
            };

            Product product2 = new Product()
            {
                Id = 2,
                Name = "product2",
                Price = 9.99m
            };

            Product product3 = new Product()
            {
                Id = 3,
                Name = "product3",
                Price = 13.99m
            };

            Order order1 = new Order()
            {
                OrderId = 101,
                Data = DateTime.Now,
                Products = new List<Product>() { product1, product2 }
            };

            Order order2 = new Order()
            {
                OrderId = 202,
                Data = DateTime.Now,
                Products = new List<Product>() { product1, product3 }
            };

            Order order3 = new Order()
            {
                OrderId = 303,
                Data = DateTime.Now,
                Products = new List<Product>() { product2 }
            };

            List<Order> orders = new List<Order>() { order1, order2, order3 };
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(orders, options);
            Console.WriteLine(json);
            File.WriteAllText("orders.json", json);
            string json2 = File.ReadAllText("orders.json");
            List<Order> orders2 = JsonSerializer.Deserialize<List<Order>>(json2);

            for (int i = 0; i < orders2.Count; i++)
            {
                Console.WriteLine("OrderId: " + orders2[i].OrderId);
                Console.WriteLine("Data: " + orders2[i].Data);

                for (int j = 0; j < orders2[i].Products.Count; j++)
                {
                    Console.WriteLine("ProductId: " + orders2[i].Products[j].Id);
                    Console.WriteLine("ProductName: " + orders2[i].Products[j].Name);
                    Console.WriteLine("ProductPrice: " + orders2[i].Products[j].Price);
                }
                Console.WriteLine();
            }
        }
    }
}
