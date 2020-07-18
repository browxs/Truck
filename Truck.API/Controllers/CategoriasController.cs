using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Truck.API.Models;
using Truck.Domain.Repositories;

namespace Truck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriasController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = (await _categoriaRepository.GetAsync())
                .Select(c => c.ToCategoriaGet());

            return Ok(data);
        }

        [HttpGet("{id}", Name = "GetCategoriaById")]
        [Produces("application/json")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _categoriaRepository.GetByIdAsync(id);

            if (data == null) return NotFound();

            return Ok(data.ToCategoriaGet());

        }

        [HttpPost]
        public IActionResult Add([FromBody] CategoriaAddEdit model)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var data = model.ToCategoria();

            _categoriaRepository.Add(data);

            return CreatedAtRoute("GetCategoriaById", new { data.Id }, data.ToCategoriaGet());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoriaAddEdit model)
        {
            var data = await _categoriaRepository.GetByIdAsync(id);

            if (data == null) ModelState.AddModelError("Id", "categoria não encontrada");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            data.Update(model.Nome);

            _categoriaRepository.Update(data);

            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _categoriaRepository.GetByIdAsync(id);

            if (data == null)
                return BadRequest(new { Categoria = new string[] { "categoria não localizada" } });

            _categoriaRepository.Delete(data);

            return Ok();
        }
    }
}
