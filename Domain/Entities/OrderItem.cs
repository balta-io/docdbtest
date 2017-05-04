using DocumentDbTest.Domain.ValueObjects;

namespace DocumentDbTest.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Price = product.Price;
            Quantity = quantity;
        }

        public Product Product { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public decimal GetTotal()
        {
            return Price * Quantity;
        }
    }
}