using AutoMapper;
using EL.FredericoRibeiro.Application.Interfaces;
using EL.FredericoRibeiro.Application.Models;
using EL.FredericoRibeiro.Domain.DbModels;
using EL.FredericoRibeiro.Domain.Interfaces;
using EL.FredericoRibeiro.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EL.FredericoRibeiro.Api.Controllers
{
    [ApiController]
    [Route("operadores")]
    public class OperadorController : ApiBaseController
    {
        private readonly IUser _user;
        private readonly IMapper _mapper;
        private readonly IOperadorApplication _operadorApplication;
        private readonly IOperadorReadOnlyRepository _operadorReadOnlyRepository;

        public OperadorController(IUser user,
            IMapper mapper, 
            IOperadorApplication operadorApplication,
            IOperadorReadOnlyRepository operadorReadOnlyRepository)
        {
            _user = user;
            _mapper = mapper;
            _operadorApplication = operadorApplication;
            _operadorReadOnlyRepository = operadorReadOnlyRepository;
        }

        /// <summary>
        /// Obtem operador pelo identificador único (Id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Operador")]
        [ProducesResponseType(typeof(OperadorModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
        {
            Log.Information($"Id do usuario logado: {_user.Name}");

            var operador = await _operadorReadOnlyRepository.ObterOperadorAsync(id);
            if (operador == null)
                return NotFound("Operador não encontrado");

            return Ok(_mapper.Map<OperadorDbModel, OperadorModel>(operador));
        }

        /// <summary>
        /// Obtem lista dos operadores cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Operador")]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {
            Log.Information($"Id do usuario logado: {_user.Name}");

            var operadores = await _operadorReadOnlyRepository.ObterOperadoresAsync();
            if (operadores == null)
                return NotFound("Operadores não encontrados");

            return Ok(_mapper.Map<IEnumerable<OperadorDbModel>, IEnumerable<OperadorModel>>(operadores));
        }

        /// <summary>
        /// Cadastra um operador
        /// </summary>
        /// <param name="operadorInclusaoModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Operador")]
        [ProducesResponseType(typeof(OperadorModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody]OperadorInclusaoModel operadorInclusaoModel)
        {
            Log.Information($"Id do usuario logado: {_user.Name}");

            var result = await _operadorApplication.Criar(operadorInclusaoModel);

            if (result.Success)
                return Created($"/operadores/{result.Object.Id}", result.Object);

            return BadRequest(result.Notifications);
        }
    }
}
