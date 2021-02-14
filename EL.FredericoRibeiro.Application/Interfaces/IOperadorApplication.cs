using EL.FredericoRibeiro.Application.Models;
using EL.FredericoRibeiro.Domain.Entities;
using System.Threading.Tasks;

namespace EL.FredericoRibeiro.Application.Interfaces
{
    public interface IOperadorApplication
    {
        Task<Result<OperadorModel>> Criar(OperadorInclusaoModel operadorInclusaoModel);
    }
}