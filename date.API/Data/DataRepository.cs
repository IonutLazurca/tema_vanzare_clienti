using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using date.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data.SqlTypes;

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

        public async Task<int> GetTotalOrders()
        {
            int totalSales = 0;            

            var result = (from co in _context.ClientOrders
                            join o in _context.Orders on co.OrderId equals o.OrderId
                            select o.Value);
            foreach (var item in result)
            {
                totalSales = item + totalSales;
            }
            return totalSales;
        }

    }
}