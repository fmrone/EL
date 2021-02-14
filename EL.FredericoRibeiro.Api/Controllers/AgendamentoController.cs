using EL.FredericoRibeiro.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EL.FredericoRibeiro.Api.Controllers
{
    [ApiController]
    [Route("agendamentos")]
    public class AgendamentoController : ApiBaseController
    {
        private readonly IUser _user;
        public AgendamentoController(IUser user)
        {
            _user = user;
        }

        [HttpGet]
        [Route("index")]
        [Authorize(Roles = "Cliente")]
        public IActionResult Index()
        {
            Log.Information($"Id do usuario logado: {_user.Name}");

            return Ok();
        }
    }
}