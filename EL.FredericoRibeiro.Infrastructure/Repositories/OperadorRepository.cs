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
    public class OperadorRepository : IOperadorReadOnlyRepository, IOperadorWriteOnlyRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        private readonly DbSet<Operador> _dataSet;

        public OperadorRepository(IMapper mapper, 
            DataContext dataContext)
        {
            _mapper = mapper ?? 
                throw new ArgumentException(nameof (mapper));

            _dataContext = dataContext ??
               throw new ArgumentNullException(nameof(dataContext));

            _dataSet = _dataContext.Set<Operador>();
        }

        public async Task<OperadorDbModel> ObterOperadorAsync(Guid id)
        {
            var operador = await _dataSet
                .AsNoTracking()
                .Include(i => i.Usuario).AsNoTracking()
                .SingleOrDefaultAsync(q => q.Id == id);

            return _mapper.Map<Operador, OperadorDbModel>(operador);
        }

        public async Task<IEnumerable<OperadorDbModel>> ObterOperadoresAsync()
        {
            var operadores = await _dataSet.AsNoTracking()
                .Include(i => i.Usuario).AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<Operador>, IEnumerable<OperadorDbModel>>(operadores);
        }

        public async Task<OperadorDbModel> CriarOperadorAsync(OperadorDbModel operadorDbModel)
        {
            Operador operador = _mapper.Map<OperadorDbModel, Operador>(operadorDbModel);

            await _dataSet.AddAsync(operador);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Operador, OperadorDbModel>(operador);
        }

        public async Task<OperadorDbModel> AtribuirUsuario(Guid operadorId, Guid usuarioId) 
        {
            var operador = await _dataSet
              .SingleOrDefaultAsync(q => q.Id == operadorId);

            if (operador == null)
                return null;

            Operador operadorToUpdate = operador;
            operadorToUpdate.UsuarioId = usuarioId;

            _dataContext
                .Entry(operador)
                .CurrentValues
                .SetValues(operadorToUpdate);

            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Operador, OperadorDbModel>(operadorToUpdate);
        }
    }
}