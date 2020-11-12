using System.Threading.Tasks;
using date.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace date.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IDataRepository _repo;

        public ClientsController(IDataRepository repo)
        {
            _repo = repo;            
        }

        [HttpGet("city/{id}")]
        public async Task<IActionResult> GetOrdersByCity (string id)
        {
            var result = await _repo.GetOrdersByCity(id);

            return Ok(result);
        }

        [HttpGet("total")]
        public async Task<IActionResult> GetTotalOrders ()
        {
            var result = await _repo.GetTotalOrders();

            return Ok(result);
        }

        [HttpGet("salesbycity")]
        public async Task<IActionResult> GetTotalOrdersByCity ()
        {
            var result = await _repo.GetTotalOrdersByCity();

            return Ok(result);
        }

        [HttpGet("filterCustomer")]
        public async Task<IActionResult> GetSpecificCustomer ([FromQuery] int salesCount, int salesValue)
        {
            var result = await _repo.GetSpecificSale(salesCount, salesValue);

            return Ok(result);
        }
        
    }
}