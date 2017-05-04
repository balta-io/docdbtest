using System;
using System.Collections.Generic;
using System.Linq;
using DocumentDbTest.Domain.ValueObjects;
using FluentValidator;

namespace DocumentDbTest.Domain.Entities
{
    public class Order : Entity
    {
        private IList<OrderItem> _items;

        public Order()
        {
            Date = DateTime.Now;
            _items = new List<OrderItem>();
        }

        public DateTime Date { get; private set; }
        public IReadOnlyCollection<OrderItem> Items
        {
            get { return _items.ToArray(); }
        }

        public void AddItem(OrderItem item)
        {
            new ValidationContract<OrderItem>(item)
                .IsGreaterThan(x => x.Price, 0)
                .IsGreaterThan(x => x.Quantity, 0)
                .IsLowerThan(x => x.Quantity, item.Product.Quantity, $"O produto { item.Product.Title } só possui { item.Product.Quantity } unidades.");

            _items.Add(item);
        }
    }
}