using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Truck.Domain.Repositories;

namespace Truck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculosController(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _veiculoRepository.GetAsync();
            return Ok(data);
        }
    }
}
