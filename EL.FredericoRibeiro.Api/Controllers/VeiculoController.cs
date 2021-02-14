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
    [Route("veiculos")]
    public class VeiculoController : ApiBaseController
    {
        private readonly IUser _user;
        public VeiculoController(IUser user) 
        {
            _user = user;
        }

        [Authorize(Roles = "Operador")]
        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            Log.Information($"Id do usuario logado: {_user.Name}");

            return Ok();
        }
    }
}
