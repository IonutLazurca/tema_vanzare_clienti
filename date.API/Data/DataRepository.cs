using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using date.API.Models;
using Microsoft.EntityFrameworkCore;

namespace date.API.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly DataContext _context;
        public DataRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<int> GetOrdersByCity(string name)
        {   
            int citySales = 0;         
            var result = await _context.ClientOrders.Include(o => o.Order).Include(c => c.Client).Where(x => x.Client.City == name).ToListAsync();

            foreach (var item in result)
            {
                citySales = citySales + item.Order.Value;
                System.Console.WriteLine(citySales);
            }
            return  citySales;

        }

        public Task<Order> GetSpecificSale(int count, int saleValue)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ClientOrder>> GetTotalOrders()
        {
            var result = await _context.ClientOrders.Include(o => o.Order).ToListAsync();

            var cities = new List<string>();
            foreach (var city in result)
            {
                if (!cities.Contains(city.Client.City.ToString()))
                {
                    cities.Add(city.ToString());
                    System.Console.WriteLine(city);
                }
            }
            
            return result;
        }
    }
}