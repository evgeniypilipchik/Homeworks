namespace Homework_13
{
    internal class Order
    {
        public int OrderId { get; set; }
        public DateTime Data {  get; set; }
        public List<Product> Products { get; set; }
    }
}