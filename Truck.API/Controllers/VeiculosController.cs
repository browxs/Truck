using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Truck.API.DTOs;
using Truck.Domain.Entities;
using Truck.Domain.Repositories;

namespace Truck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public VeiculosController(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna todos os veiculos
        /// </summary>
        /// <remarks>
        /// Retorna uma lista de todos os veiculos
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">Veiculos encontrados</response>
        /// <response code="400">Veiculos não encontrados</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var veiculos = await _veiculoRepository.GetAllWithCategoriaAsync();

            if (veiculos == null)
            {
                return NotFound("Veiculos não encontradas");
            }

            var veiculosDto = _mapper.Map<List<VeiculoCategoriaDTO>>(veiculos);

            return Ok(veiculosDto);
        }

        /// <summary>
        /// Retorna veiculo pelo id
        /// </summary>
        /// <remarks>
        /// Retorna veiculo pelo id
        /// </remarks>
        /// <param name="id">Id do veiculo</param>
        /// <returns></returns>
        /// <response code="200">Veiculo encontrada</response>
        /// <response code="404">Veiculo não encontrada</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var veiculo = await _veiculoRepository.GetByIdWithCategoriaAsync(id);

            if (veiculo == null)
            {
                return NotFound("Veiculo não encontrada");
            }

            var veiculoDto = _mapper.Map<VeiculoCategoriaDTO>(veiculo);

            return Ok(veiculoDto);
        }

        /// <summary>
        /// Retorna todos os veículos filtrados por marca
        /// </summary>
        /// <remarks>
        /// Retorna uma lista de todos os veículos filtrados por marca
        /// </remarks>
        /// <param name="marca">Marcas dos veículos</param>
        /// <returns></returns>
        /// <response code="200">Marca encontrada</response>
        /// <response code="404">Marca não encontrada</response>
        [HttpGet("marca/{marca}")]
        public async Task<IActionResult> GetByMarca(string marca)
        {
            var veiculo = await _veiculoRepository.GetByMarcaAsync(marca);

            if (veiculo == null)
            {
                return NotFound("Veiculo não encontrada");
            }

            var veiculoDto = _mapper.Map<List<VeiculoRespostaDTO>>(veiculo);

            return Ok(veiculoDto);
        }

        /// <summary>
        /// Adiciona um novo veiculo
        /// </summary>
        /// <remarks>
        /// Adiciona um novo veiculo
        /// </remarks>
        /// <param name="veiculoDto">Veiculo para adicionar</param>
        /// <returns></returns>
        /// <response code="200">Veiculo adicionado</response>
        /// <response code="400">Falha ao adicionar veiculo</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VeiculoDTO veiculoDto)
        {
            var veiculo = _mapper.Map<Veiculo>(veiculoDto);

            _veiculoRepository.Add(veiculo);

            if (await _veiculoRepository.CommitAsync())
            {
                var data = _mapper.Map<VeiculoRespostaDTO>(veiculo);
                return Ok(data);
            }
            else
            {
                return BadRequest("Falha ao adicionar veiculo");
            }
        }

        /// <summary>
        /// Atualiza um veiculo existente
        /// </summary>
        /// <param name="id">Id do veiculo</param>
        /// <param name="veiculoDto">Veiculo para atualizar</param>
        /// <returns></returns>
        /// <response code="200">Veiculo atualizado</response>
        /// <response code="400">Falha ao atualizar veiculo</response>
        /// <response code="404">Veiculo não localizado</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] VeiculoRespostaDTO veiculoDto)
        {
            if (id != veiculoDto.Id)
            {
                return NotFound("Veiculo não encontrada");
            }

            var data = _mapper.Map<Veiculo>(veiculoDto);
            _veiculoRepository.Update(data);

            if (await _veiculoRepository.CommitAsync())
            {
                return Ok();
            }
            else
            {
                return BadRequest("Falha ao atualizar veiculo");
            }
        }

        /// <summary>
        /// Exclui um veiculo
        /// </summary>
        /// <remarks>
        /// Exclui um veiculo
        /// </remarks>
        /// <param name="id">Id do veiculo para excluir</param>
        /// <returns></returns>   
        /// <response code="200">Veiculo excluído</response>
        /// <response code="400">Falha ao excluir veiculo</response>
        /// <response code="404">Veiculo não encontrado</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _veiculoRepository.GetByIdAsync(id);

            if (data == null)
            {
                return NotFound("Veiculo não encontrada");
            }

            _veiculoRepository.Delete(data);

            if (await _veiculoRepository.CommitAsync())
            {
                return Ok();
            }
            else
            {
                return BadRequest("Falha ao excluir veiculo");
            }
        }
    }
}
