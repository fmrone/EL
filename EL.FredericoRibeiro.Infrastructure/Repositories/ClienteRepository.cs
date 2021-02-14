using AutoMapper;
using EL.FredericoRibeiro.Domain.DbModels;
using EL.FredericoRibeiro.Domain.Repositories;
using EL.FredericoRibeiro.Infrastructure.Data.Context;
using EL.FredericoRibeiro.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EL.FredericoRibeiro.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteReadOnlyRepository, IClienteWriteOnlyRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        private readonly DbSet<Cliente> _dataSet;

        public ClienteRepository(IMapper mapper, 
            DataContext dataContext)
        {
            _mapper = mapper ?? 
                throw new ArgumentException(nameof (mapper));

            _dataContext = dataContext ??
               throw new ArgumentNullException(nameof(dataContext));

            _dataSet = _dataContext.Set<Cliente>();
        }

        public async Task<ClienteDbModel> ObterClienteAsync(Guid id)
        {
            var cliente = await _dataSet
                .AsNoTracking()
                .Include(i => i.Usuario).AsNoTracking()
                .SingleOrDefaultAsync(q => q.Id == id);

            return _mapper.Map<Cliente, ClienteDbModel>(cliente);
        }

        public async Task<IEnumerable<ClienteDbModel>> ObterClientesAsync()
        {
            var clientes = await _dataSet.AsNoTracking()
                .Include(i => i.Usuario).AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteDbModel>>(clientes);
        }

        public async Task<ClienteDbModel> CriarClienteAsync(ClienteDbModel clienteDbModel)
        {
            Cliente cliente = _mapper.Map<ClienteDbModel, Cliente>(clienteDbModel);

            await _dataSet.AddAsync(cliente);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Cliente, ClienteDbModel>(cliente);
        }

        public async Task<ClienteDbModel> AlterarClienteAsync(ClienteDbModel clienteDbModel)
        {
            var cliente = await _dataSet
                .SingleOrDefaultAsync(q => q.Id == clienteDbModel.Id);

            if (cliente == null)
                return null;

            Cliente clienteToUpdate = _mapper
                .Map<ClienteDbModel, Cliente>(clienteDbModel);

            _dataContext
                .Entry(cliente)
                .CurrentValues
                .SetValues(clienteToUpdate);

            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Cliente, ClienteDbModel>(clienteToUpdate);
        }

        public async Task<bool> ExcluirClienteAsync(Guid id)
        {
            try
            {
                var cliente = await _dataSet
                    .SingleOrDefaultAsync(q => q.Id == id);

                if (cliente != null)
                    _dataSet.Remove(cliente);

                await _dataContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ClienteDbModel> AtribuirUsuario(Guid clienteId, Guid usuarioId) 
        {
            var cliente = await _dataSet
              .SingleOrDefaultAsync(q => q.Id == clienteId);

            if (cliente == null)
                return null;

            Cliente clienteToUpdate = cliente;
            clienteToUpdate.UsuarioId = usuarioId;

            _dataContext
                .Entry(cliente)
                .CurrentValues
                .SetValues(clienteToUpdate);

            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Cliente, ClienteDbModel>(clienteToUpdate);
        }
    }
}