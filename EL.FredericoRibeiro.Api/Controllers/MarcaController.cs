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
    [Route("marcas")]
    public class MarcaController : ApiBaseController
    {
        private readonly IUser _user;
        public MarcaController(IUser user)
        {
            _user = user;
        }

        [HttpGet]
        [Route("index")]
        [Authorize(Roles = "Operador")]
        public IActionResult Index()
        {
            Log.Information($"Id do usuario logado: {_user.Name}");

            return Ok();
        }
    }
}
