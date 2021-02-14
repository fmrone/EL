using EL.FredericoRibeiro.Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EL.FredericoRibeiro.Domain.Repositories
{
    public interface IClienteWriteOnlyRepository
    {
        Task<ClienteDbModel> CriarClienteAsync(ClienteDbModel clienteDbModel);
        Task<ClienteDbModel> AlterarClienteAsync(ClienteDbModel clienteDbModel);
        Task<bool> ExcluirClienteAsync(Guid id);
        Task<ClienteDbModel> AtribuirUsuario(Guid clienteId, Guid usuarioId);
    }
}
