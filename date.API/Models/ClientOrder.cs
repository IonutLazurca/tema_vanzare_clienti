namespace date.API.Models
{
    public class ClientOrder
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}