using EL.FredericoRibeiro.Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EL.FredericoRibeiro.Domain.Repositories
{
    public interface IUsuarioWriteOnlyRepository
    {
        Task<UsuarioDbModel> CriarUsuarioAsync(UsuarioDbModel usuarioDbModel);
    }
}
