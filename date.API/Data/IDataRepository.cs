using System.Collections.Generic;
using System.Threading.Tasks;
using date.API.Dtos;
using date.API.Models;

namespace date.API.Data
{
    public interface IDataRepository
    {
         Task<int> GetTotalOrders();        
         Task<int> GetOrdersByCity(string name);
         Task<List<CityTotalDto>> GetTotalOrdersByCity();
         Task<Order> GetSpecificSale(int count, int saleValue);
    }
}