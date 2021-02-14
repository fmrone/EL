using EL.FredericoRibeiro.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EL.FredericoRibeiro.Api.Controllers
{
    [ApiController]
    [Route("contratos")]
    public class ContratoController : ApiBaseController
    {
        private readonly IUser _user;

        public ContratoController(IUser user)
        {
            _user = user;
        }

        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}