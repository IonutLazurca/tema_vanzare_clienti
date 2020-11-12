using System.Collections.Generic;
using System.Linq;
using date.API.Models;

namespace date.API.Data
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Clients.Any() && !context.Orders.Any())
            {
                var clients = new List<Client>
                {
                    new Client{ClientId = 1, Name = "Alice", City = "Bucharest"},
                    new Client{ClientId = 2, Name = "Bob", City = "Belgrade"},
                    new Client{ClientId = 3, Name = "Charlie", City = "Budapest"},
                    new Client{ClientId = 4, Name = "Dan", City = "Bucharest"}
                };

                var orders = new List<Order>
                {
                    new Order{OrderId = 1, Value = 21 },
                    new Order{OrderId = 2, Value = 2 },
                    new Order{OrderId = 3, Value = 12 },
                    new Order{OrderId = 4, Value = 34 },
                    new Order{OrderId = 5, Value = 13 },
                    new Order{OrderId = 6, Value = 12 },
                    new Order{OrderId = 7, Value = 9 },
                    new Order{OrderId = 8, Value = 12 },
                    new Order{OrderId = 9, Value = 12 }
                };

                var clientOrders = new List<ClientOrder>
                {
                    new ClientOrder{OrderId = 1, ClientId = 1 },
                    new ClientOrder{OrderId = 2, ClientId = 1 },
                    new ClientOrder{OrderId = 3, ClientId = 1 },
                    new ClientOrder{OrderId = 4, ClientId = 2 },
                    new ClientOrder{OrderId = 5, ClientId = 2 },
                    new ClientOrder{OrderId = 6, ClientId = 3 },
                    new ClientOrder{OrderId = 7, ClientId = 3 },
                    new ClientOrder{OrderId = 8, ClientId = 4 },
                    new ClientOrder{OrderId = 9, ClientId = 2 }
                };

                foreach (var client in clients)
                {
                    context.Clients.Add(client);                    
                }

                foreach (var order in orders)
                {
                    context.Orders.Add(order);
                }

                foreach (var clientOrder in clientOrders)
                {
                    context.ClientOrders.Add(clientOrder);
                }

                context.SaveChanges();
            }

            
        }
        
    }
}
