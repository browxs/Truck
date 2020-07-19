using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Truck.API.DTOs;
using Truck.Domain.Entities;
using Truck.Domain.Repositories;

namespace Truck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todas as categorias com veículos
        /// </summary>
        /// <remarks>
        /// Traz uma lista de todas as categorias com veículos
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">Categorias encontradas</response>
        /// <response code="400">Categorias não encontradas</response>
        [HttpGet("veiculos")]
        public async Task<IActionResult> GetWithVeiculos()
        {
            var categorias = await _categoriaRepository.GetAllWithVeiculosAsync();

            if (categorias == null)
            {
                return NotFound("Categorias não encontradas");
            }

            var categoriasDto = _mapper.Map<List<CategoriaVeiculosDTO>>(categorias);

            return Ok(categoriasDto);
        }

        /// <summary>
        /// Retorna todas as categorias
        /// </summary>
        /// <remarks>
        /// Traz uma lista de todas as categorias
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">Categorias encontradas</response>
        /// <response code="400">Categorias não encontradas</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categorias = await _categoriaRepository.Get().ToListAsync();

            if (categorias == null)
            {
                return NotFound("Categorias não encontradas");
            }

            var categoriasDto = _mapper.Map<List<CategoriaRespostaDTO>>(categorias);

            return Ok(categoriasDto);
        }

        /// <summary>
        /// Retorna categoria pelo id
        /// </summary>
        /// <remarks>
        /// Retorna categoria pelo id
        /// </remarks>
        /// <param name="id">Id da categoria</param>
        /// <returns></returns>
        /// <response code="200">Categoria encontrada</response>
        /// <response code="404">Categoria não encontrada</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);

            if (categoria == null)
            {
                return NotFound("Categoria não encontrada");
            }

            var categoriaDto = _mapper.Map<CategoriaRespostaDTO>(categoria);

            return Ok(categoriaDto);
        }

        /// <summary>
        /// Adiciona uma nova categoria
        /// </summary>
        /// <remarks>
        /// Adiciona uma nova categoria
        /// </remarks>
        /// <param name="categoriaDto">Categoria para adicionar</param>
        /// <returns></returns>
        /// <response code="200">Categoria adicionada</response>
        /// <response code="400">Falha ao adicionar categoria</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriaDTO categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);

            _categoriaRepository.Add(categoria);

            if (await _categoriaRepository.CommitAsync())
            {
                var data = _mapper.Map<CategoriaRespostaDTO>(categoria);
                return Ok(data);
            }
            else
            {
                return BadRequest("Falha ao adicionar categoria");
            }
        }

        /// <summary>
        /// Atualiza uma categoria existente
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <param name="categoriaDto">Categoria para atualizar</param>
        /// <returns></returns>
        /// <response code="200">Categoria atualizada</response>
        /// <response code="400">Falha ao atualizar categoria</response>
        /// <response code="404">Categoria não localizada</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoriaRespostaDTO categoriaDto)
        {
            if (id != categoriaDto.Id)
            {
                return NotFound("Categoria não encontrada");
            }

            var data = _mapper.Map<Categoria>(categoriaDto);
            _categoriaRepository.Update(data);

            if (await _categoriaRepository.CommitAsync())
            {
                return Ok();
            }
            else
            {
                return BadRequest("Falha ao atualizar categoria");
            }
        }

        /// <summary>
        /// Exclui uma categoria
        /// </summary>
        /// <remarks>
        /// Exclui uma categoria
        /// </remarks>
        /// <param name="id">Id da categoria para excluir</param>
        /// <returns></returns>   
        /// <response code="200">Categoria excluída</response>
        /// <response code="400">Falha ao excluir categoria</response>
        /// <response code="404">Categoria não encontrada</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _categoriaRepository.GetByIdAsync(id);

            if (data == null)
            {
                return NotFound("Categoria não encontrada");
            }

            _categoriaRepository.Delete(data);

            if (await _categoriaRepository.CommitAsync())
            {
                return Ok();
            }
            else
            {
                return BadRequest("Falha ao excluir categoria");
            }
        }
    }
}
