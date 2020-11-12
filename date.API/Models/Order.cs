using System.Collections.Generic;

namespace date.API.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int Value { get; set; }
        public ICollection<ClientOrder> ClientOrders { get; set; }
    }
}