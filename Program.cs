using System;
using System.Threading.Tasks;
using DocumentDbTest.Domain.Entities;
using DocumentDbTest.Domain.ValueObjects;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace DocumentDbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.GetStartedDemo().Wait();

            Console.ReadKey();
        }

        private async Task GetStartedDemo()
        {
            // Gera um novo cliente
            var customer = new Customer(new Name("André", "Baltieri"), new Domain.ValueObjects.Document("57673386801"), new Email("hello@balta.io"));
            var mouse = new Product("Apple Magic Mouse", 599M, 2);

            // Gera um novo pedido
            var order = new Order();
            order.AddItem(new OrderItem(mouse, 2));

            // Percorre todos os itens do pedido
            foreach (var item in order.Items)
            {
                // Exibe as possíveis notificações
                foreach (var notification in item.Notifications)
                {
                    Console.WriteLine(notification.Message);
                }
            }

            await Save(order);
        }

        private async Task Save(object obj)
        {
            try
            {
                var EndpointUri = "https://balta.documents.azure.com:443/";
                var PrimaryKey = "dTnWdd23isTXYFewhJk8j9viGASNbCzXMwYlFbtdSLfTmHYsUyhuzxQXumh2zJzLTvCZe3TapcIN9WO3aNEsWw==";
                var client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);
                await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri("balta", "orders"), obj);
            }
            catch (DocumentClientException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
