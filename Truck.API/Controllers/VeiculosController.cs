using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Truck.API.Models;
using Truck.Domain.Repositories;

namespace Truck.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public VeiculosController(IVeiculoRepository veiculoRepository, ICategoriaRepository categoriaRepository)
        {
            _veiculoRepository = veiculoRepository;
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = (await _veiculoRepository.GetAllWithCategoriaAsync())
                .Select(p => p.ToVeiculoGet());
            return Ok(data);
        }

        [HttpGet("{id}", Name = "GetVeiculoById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _veiculoRepository.GetByIdWithCategoriaAsync(id);

            if (data == null) return NotFound();

            return Ok(data?.ToVeiculoGet());
        }

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="model"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] VeiculoAddEdit model)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(model.CategoriaId);

            if (categoria == null)
                ModelState.AddModelError("CategoriaId", "Categoria inválida");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var data = model.ToVeiculo();
            _veiculoRepository.Add(data);

            var veiculo = data.ToVeiculoGet();
            veiculo.CategoriaNome = categoria.Nome;

            return CreatedAtRoute("GetVeiculoById", new { veiculo.Id }, veiculo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VeiculoAddEdit model)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(model.CategoriaId);

            if (categoria == null)
                ModelState.AddModelError("CategoriaId", "Categoria inválida");

            var veiculo = await _veiculoRepository.GetByIdAsync(id);

            if (veiculo == null) ModelState.AddModelError("Id", "veiculo não localizado");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            veiculo.Update(model.Marca, model.Modelo, model.Preco, model.CategoriaId );
            _veiculoRepository.Update(veiculo);

            return Ok();
        }

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="id"></param>    
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _veiculoRepository.GetByIdAsync(id);

            if (data == null)
                return BadRequest(new { Veiculo = new string[] { "veiculo não localizado" } });

            _veiculoRepository.Delete(data);

            return Ok();
        }
    }
}
