using AutoMapper;
using EL.FredericoRibeiro.Application.Interfaces;
using EL.FredericoRibeiro.Application.Models;
using EL.FredericoRibeiro.Domain.DbModels;
using EL.FredericoRibeiro.Domain.Entities;
using EL.FredericoRibeiro.Domain.Repositories;
using System.Threading.Tasks;

namespace EL.FredericoRibeiro.Application
{
    public class ClienteApplication : IClienteApplication
    {
        private readonly IMapper _mapper;
        private readonly IClienteWriteOnlyRepository _clienteWriteOnlyRepository;

        public ClienteApplication(IMapper mapper,
            IClienteWriteOnlyRepository clienteWriteOnlyRepository)
        {
            _mapper = mapper;
            _clienteWriteOnlyRepository = clienteWriteOnlyRepository;
        }

        public async Task<Result<ClienteModel>> Criar(ClienteInclusaoModel clienteInclusaoModel)
        {
            var cliente = _mapper.Map<ClienteInclusaoModel, Cliente>(clienteInclusaoModel);
            
            if (!cliente.Valid)
                return Result<ClienteModel>.Error(cliente.Notifications);

            await _clienteWriteOnlyRepository
                .CriarClienteAsync(_mapper.Map<Cliente, ClienteDbModel>(cliente));

            return Result<ClienteModel>.Ok(_mapper.Map<Cliente, ClienteModel>(cliente));
        }
    }
}
