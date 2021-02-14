using AutoMapper;
using EL.FredericoRibeiro.Application.Interfaces;
using EL.FredericoRibeiro.Application.Models;
using EL.FredericoRibeiro.Domain.DbModels;
using EL.FredericoRibeiro.Domain.Entities;
using EL.FredericoRibeiro.Domain.Repositories;
using System.Threading.Tasks;

namespace EL.FredericoRibeiro.Application
{
    public class OperadorApplication : IOperadorApplication
    {
        private readonly IMapper _mapper;
        private readonly IOperadorWriteOnlyRepository _operadorWriteOnlyRepository;

        public OperadorApplication(IMapper mapper,
            IOperadorWriteOnlyRepository operadorWriteOnlyRepository)
        {
            _mapper = mapper;
            _operadorWriteOnlyRepository = operadorWriteOnlyRepository;
        }

        public async Task<Result<OperadorModel>> Criar(OperadorInclusaoModel operadorInclusaoModel)
        {
            var operador = _mapper.Map<OperadorInclusaoModel, Operador>(operadorInclusaoModel);
            
            if (!operador.Valid)
                return Result<OperadorModel>.Error(operador.Notifications);

            await _operadorWriteOnlyRepository
                .CriarOperadorAsync(_mapper.Map<Operador, OperadorDbModel>(operador));

            return Result<OperadorModel>.Ok(_mapper.Map<Operador, OperadorModel>(operador));
        }
    }
}
