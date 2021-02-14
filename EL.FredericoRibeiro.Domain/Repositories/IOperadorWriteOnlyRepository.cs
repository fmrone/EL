using EL.FredericoRibeiro.Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EL.FredericoRibeiro.Domain.Repositories
{
    public interface IOperadorWriteOnlyRepository
    {
        Task<OperadorDbModel> CriarOperadorAsync(OperadorDbModel operadorDbModel);
        Task<OperadorDbModel> AtribuirUsuario(Guid operadorId, Guid usuarioId);
    }
}
