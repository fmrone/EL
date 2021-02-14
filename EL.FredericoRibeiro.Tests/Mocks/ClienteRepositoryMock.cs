using EL.FredericoRibeiro.Domain.DbModels;
using EL.FredericoRibeiro.Domain.Entities;
using EL.FredericoRibeiro.Domain.Repositories;
using EL.FredericoRibeiro.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EL.FredericoRibeiro.Tests.Mocks
{
    public class ClienteReadOnlyRepositoryMock : IClienteReadOnlyRepository
    {
        private readonly List<ClienteDbModel> clientesDbModel;

        public ClienteReadOnlyRepositoryMock() 
        {
            clientesDbModel = new List<ClienteDbModel>
            { 
                new ClienteDbModel 
                { 
                    Id = Guid.Parse("42f41603-5269-4c0d-9ce2-afa8d293240b"),
                    Nome = "Tony Stark",
                    Cpf = "03544363221",
                    Aniversario = 1610,
                    Cep = 12345,
                    Logradouro = "Stark Street",
                    Numero = 10,
                    Cidade = "Malibu",
                    Estado = "CA"
                },
                new ClienteDbModel
                {      
                    Id = Guid.Parse("3dd64d9c-aaef-4a98-9b2c-5f6d7fc28ead"),
                    Nome = "Peter Parker",
                    Cpf = "09854361612",
                    Aniversario = 1610,
                    Cep = 12345,
                    Logradouro = "Parker Street",
                    Numero = 10,
                    Cidade = "New York",
                    Estado = "NY"
                }
            };
        }

        public async Task<ClienteDbModel> ObterClienteAsync(Guid id)
        {
            var cliente = clientesDbModel.FirstOrDefault(q => q.Id == id);
            return cliente;
        }

        public Task<IEnumerable<ClienteDbModel>> ObterClientesAsync()
        {
            throw new NotImplementedException();
        }
    }

    public class ClienteWriteRepositoryMock : IClienteWriteOnlyRepository
    {
        public Task<ClienteDbModel> AlterarClienteAsync(ClienteDbModel clienteDbModel)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDbModel> AtribuirUsuario(Guid clienteId, Guid usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDbModel> CriarClienteAsync(ClienteDbModel clienteDbModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirClienteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
