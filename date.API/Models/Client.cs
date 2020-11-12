using System.Collections.Generic;

namespace date.API.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public ICollection<ClientOrder> ClientOrders { get; set; }

    }
}