using EL.FredericoRibeiro.Domain.Entities;
using EL.FredericoRibeiro.Domain.ValueObjects;
using System;
using Xunit;

namespace EL.FredericoRibeiro.Tests.Domain
{
    public class ClienteTest
    {
        [Fact]
        public void CriarCliente_ClienteInvalido_Test()
        {
            var cliente = new Cliente(null, new CPF("1"), 1515, 0, null, 0, null, null, "123");

            Assert.True(cliente.Invalid);
            Assert.Contains(cliente.Notifications, n => n.Property == nameof(Cliente.Nome));
            Assert.Contains(cliente.Notifications, n => n.Property == nameof(Cliente.Logradouro));
            Assert.Contains(cliente.Notifications, n => n.Property == nameof(Cliente.Cidade));
            Assert.Contains(cliente.Notifications, n => n.Property == nameof(Cliente.Estado));
        }

        [Fact]
        public void CriarCliente_ClienteValido_Test()
        {
            var cliente = new Cliente("Tony Stark",
                new CPF("12345678911"),
                1610,
                32115000,
                "Stark Street",
                10,
                null,
                "Malibu",
                "CA");

            Assert.True(cliente.Valid);
        }
    }
}
