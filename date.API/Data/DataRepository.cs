using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using date.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using date.API.Dtos;

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
            }
            System.Console.WriteLine(citySales);

            return  citySales;
        }

        public async Task<CustomerSpecSales> GetSpecificSale(int salesCount, int salesValue)
        {
            var customers = new List<string>();
            var result = await _context.ClientOrders.Include(o => o.Order).Include(c => c.Client).ToListAsync();
            foreach (var item in result)
            {
                if (!customers.Contains(item.Client.Name))
                {
                    customers.Add(item.Client.Name);
                };           
            }

            var totals = new List<CustomerSpecSales>();
            
            foreach (var customer in customers)
            {
                int totalSales = 0;
                int count = 0;
                foreach (var res in result)
                {
                    if (res.Client.Name == customer)
                    {                        
                        totalSales = totalSales + res.Order.Value;
                        count++;
                    }                    
                }
                totals.Add(new CustomerSpecSales {Name = customer, TotalSales = totalSales, SalesCount = count});
            }

            var customerIndex = totals.FindIndex(x => x.SalesCount >= salesCount && x.TotalSales >= salesValue);

            return totals[customerIndex];
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
            System.Console.WriteLine(totalSales);
            return totalSales;
        }

        public async Task<List<CityTotalDto>> GetTotalOrdersByCity()
        {   
            var cities = new List<string>();
            var result = await _context.ClientOrders.Include(o => o.Order).Include(c => c.Client).ToListAsync();
            foreach (var item in result)
            {
                if (!cities.Contains(item.Client.City))
                {
                    cities.Add(item.Client.City);
                };           
            }

            var totals = new List<CityTotalDto>();
            
            foreach (var city in cities)
            {
                int totalSales = 0;
                foreach (var res in result)
                {
                    if (res.Client.City == city)
                    {                        
                        totalSales = totalSales + res.Order.Value;
                    }                    
                }
                totals.Add(new CityTotalDto {Name = city, TotalSales = totalSales});
            }
             return totals;
        }
    }
}