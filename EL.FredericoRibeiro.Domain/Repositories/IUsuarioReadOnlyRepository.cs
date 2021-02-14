using EL.FredericoRibeiro.Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EL.FredericoRibeiro.Domain.Repositories
{
    public interface IUsuarioReadOnlyRepository
    {
        Task<UsuarioDbModel> ObterUsuarioAsync(Guid id);
        Task<UsuarioDbModel> AutenticarUsuarioAsync(string login, string senha);
    }
}
