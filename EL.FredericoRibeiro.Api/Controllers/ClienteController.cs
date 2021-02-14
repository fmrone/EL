using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EL.FredericoRibeiro.Application.Interfaces;
using EL.FredericoRibeiro.Application.Models;
using EL.FredericoRibeiro.Domain.Entities;
using EL.FredericoRibeiro.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EL.FredericoRibeiro.Domain.DbModels;

namespace EL.FredericoRibeiro.Api.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IClienteApplication _clienteApplication;
        private readonly IClienteReadOnlyRepository _clienteReadOnlyRepository;

        public ClienteController(IMapper mapper, 
            IClienteApplication clienteApplication,
            IClienteReadOnlyRepository clienteReadOnlyRepository)
        {
            _mapper = mapper;
            _clienteApplication = clienteApplication;
            _clienteReadOnlyRepository = clienteReadOnlyRepository;
        }

        /// <summary>
        /// Obtem cliente pelo identificador único (Id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
        {
            var cliente = await _clienteReadOnlyRepository.ObterClienteAsync(id);
            if (cliente == null)
                return NotFound("Cliente não encontrado");

            return Ok(_mapper.Map<ClienteDbModel, ClienteModel>(cliente));
        }

        /// <summary>
        /// Obtem lista dos clientes cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {
            var clientes = await _clienteReadOnlyRepository.ObterClientesAsync();
            if (clientes == null)
                return NotFound("Clientes não encontrados");

            return Ok(_mapper.Map<IEnumerable<ClienteDbModel>, IEnumerable<ClienteModel>>(clientes));
        }

        /// <summary>
        /// Cadastra um cliente
        /// </summary>
        /// <param name="clienteInclusaoModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody]ClienteInclusaoModel clienteInclusaoModel)
        {
            var result = await _clienteApplication.Criar(clienteInclusaoModel);

            if (result.Success)
                return Created($"/clientes/{result.Object.Id}", result.Object);

            return BadRequest(result.Notifications);
        }
    }
}
