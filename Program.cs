using System;
using DocumentDbTest.Domain.Entities;
using DocumentDbTest.Domain.ValueObjects;

namespace DocumentDbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Gera um novo cliente
            var customer = new Customer(new Name("André", "Baltieri"), new Document("57673386801"), new Email("hello@balta.io"));
            var mouse = new Product("Apple Magic Mouse", 599M, 2);

            // Gera um novo pedido
            var order = new Order();
            order.AddItem(new OrderItem(mouse, 5));

            // Percorre todos os itens do pedido
            foreach (var item in order.Items)
            {
                // Exibe as possíveis notificações
                foreach (var notification in item.Notifications)
                {
                    Console.WriteLine(notification.Message);
                }
            }

            

            Console.ReadKey();
        }
    }
}
