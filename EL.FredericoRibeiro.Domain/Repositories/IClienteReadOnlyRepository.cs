using EL.FredericoRibeiro.Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EL.FredericoRibeiro.Domain.Repositories
{
    public interface IClienteReadOnlyRepository
    {
        Task<ClienteDbModel> ObterClienteAsync(Guid id);
        Task<IEnumerable<ClienteDbModel>> ObterClientesAsync();
    }
}
