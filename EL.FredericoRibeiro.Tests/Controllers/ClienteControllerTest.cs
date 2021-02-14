using Microsoft.AspNetCore.Mvc;
using EL.FredericoRibeiro.Api.Controllers;
using EL.FredericoRibeiro.Application;
using EL.FredericoRibeiro.Application.Models;
using EL.FredericoRibeiro.Tests.Fixtures;
using EL.FredericoRibeiro.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EL.FredericoRibeiro.Tests.Controllers
{
    [Collection("Mapper")]
    public class ClienteControllerTest
    {
        private readonly MapperFixture _mapperFixture;

        public ClienteControllerTest(MapperFixture mapperFixture)
        {
            _mapperFixture = mapperFixture;
        }

        [Theory]
        [InlineData("42f41603-5269-4c0d-9ce2-afa8d293240b")]
        [InlineData("3dd64d9c-aaef-4a98-9b2c-5f6d7fc28ead")]
        public void ObterDadosCliente_Clientesexistentes_Test(string id)
        {
            var controller = CreateClienteController();
            var result = controller.Get(Guid.Parse(id));

            Assert.IsType<OkObjectResult>(result.Result);
        }

        private ClienteController CreateClienteController()
        {
            var clienteWriteOnlyRepository = new ClienteWriteRepositoryMock();
            var clienteReadOnlyRepository = new ClienteReadOnlyRepositoryMock();
            var clienteApplication = new ClienteApplication(_mapperFixture.Mapper, clienteWriteOnlyRepository);

            return new ClienteController(_mapperFixture.Mapper, clienteApplication, clienteReadOnlyRepository);
        }

        private T GetOkObject<T>(IActionResult result)
        {
            var okObjectResult = (OkObjectResult)result;
            return (T)okObjectResult.Value;
        }
    }
}
