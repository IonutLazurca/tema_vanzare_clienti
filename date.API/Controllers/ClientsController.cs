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

        [HttpGet("{id}", Name = "GetCitySale")]
        public async Task<IActionResult> GetOrdersByCity ([FromQuery] string id)
        {
            var result = await _repo.GetOrdersByCity(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTotalOrders ()
        {
            var result = await _repo.GetTotalOrders();

            return Ok(result);
        }
        
    }
}