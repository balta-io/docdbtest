using DocumentDbTest.Domain.ValueObjects;

namespace DocumentDbTest.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string title, decimal price, int quantity)
        {
            Title = title;
            Price = price;
            Quantity = quantity;
        }

        public string Title { get; private set; }
        public decimal Price { get; private set; } // Sim, isto podia ser um VO!
        public int Quantity { get; private set; }
    }
}