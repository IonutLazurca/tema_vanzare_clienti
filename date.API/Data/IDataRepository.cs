using System.Collections.Generic;
using System.Threading.Tasks;
using date.API.Models;

namespace date.API.Data
{
    public interface IDataRepository
    {
         Task<IEnumerable<ClientOrder>> GetTotalOrders();        
         Task<int> GetOrdersByCity(string name);
         Task<Order> GetSpecificSale(int count, int saleValue);
    }
}