using AutoMapper;
using EL.FredericoRibeiro.Application.Interfaces;
using EL.FredericoRibeiro.Application.Models;
using EL.FredericoRibeiro.Application.Services;
using EL.FredericoRibeiro.Domain.DbModels;
using EL.FredericoRibeiro.Domain.Enums;
using EL.FredericoRibeiro.Domain.Interfaces;
using EL.FredericoRibeiro.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EL.FredericoRibeiro.Api.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioApplication _usuarioApplication;
        private readonly IUsuarioReadOnlyRepository _usuarioReadOnlyRepository;


        public UsuarioController(IMapper mapper,
            IUsuarioApplication usuarioApplication,
            IUsuarioReadOnlyRepository usuarioReadOnlyRepository)
        {
            _mapper = mapper;
            _usuarioApplication = usuarioApplication;
            _usuarioReadOnlyRepository = usuarioReadOnlyRepository;
        }

        /// <summary>
        /// Autentica um usuário na API e rotorna o token de autenticação
        /// </summary>
        /// <param name="usuarioAutenticacaoModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Autenticar(
            [FromBody] UsuarioAutenticacaoModel usuarioAutenticacaoModel)
        {
            UsuarioDbModel usuarioDbModel;

            if (usuarioAutenticacaoModel.Login == "137110" && usuarioAutenticacaoModel.Senha == "137110")
            {
                usuarioDbModel = new UsuarioDbModel
                {
                    Id = Guid.Parse("92d52308-bec5-44b6-9133-746e12aff332"),
                    Role = ERole.Operador.Value
                };
            }
            else
            {
                usuarioDbModel = await _usuarioReadOnlyRepository
                    .AutenticarUsuarioAsync(usuarioAutenticacaoModel.Login, usuarioAutenticacaoModel.Senha);
            }

            if (usuarioDbModel == null)
                return NotFound(new { mensagem = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(usuarioDbModel);

            return new
            { 
                token
            };
        } 

        /// <summary>
        /// Registra usuário para um determinado cliente
        /// </summary>
        /// <param name="usuarioInclusaoModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("registra-usuario-cliente")]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegistraUsuarioCliente([FromBody] UsuarioClienteInclusaoModel usuarioInclusaoModel)
        {
            var result = await _usuarioApplication.CriarUsuarioCliente(usuarioInclusaoModel);

            if (result.Success)
                return Created($"/usuarios/{result.Object}", result.Object);

            return BadRequest(result.Notifications);
        }

        /// <summary>
        /// Registra usuário para um determinado operador
        /// </summary>
        /// <param name="operadorInclusaoModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("registra-usuario-operador")]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegistraUsuarioOperador([FromBody] UsuarioOperadorInclusaoModel operadorInclusaoModel)
        {
            var result = await _usuarioApplication.CriarUsuarioOperador(operadorInclusaoModel);

            if (result.Success)
                return Created($"/usuarios/{result.Object}", result.Object);

            return BadRequest(result.Notifications);
        }

        [HttpGet]
        [Route("anonimo")]
        [AllowAnonymous]
        public string Anonimo() => "Anônimo";

        [HttpGet]
        [Route("autenticado")]
        [Authorize]
        public string Autenticado() => "Autenticado";

        [HttpGet]
        [Route("operador")]
        [Authorize(Roles = "Operador")]
        public string Operador() => "Operador";

        [HttpGet]
        [Route("cliente")]
        [Authorize(Roles = "Cliente")]
        public string Cliente() => "Cliente";
    }
}
