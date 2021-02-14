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
    public class UsuarioRepository : IUsuarioReadOnlyRepository, IUsuarioWriteOnlyRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        private readonly DbSet<Usuario> _dataSet;

        public UsuarioRepository(IMapper mapper, 
            DataContext dataContext)
        {
            _mapper = mapper ?? 
                throw new ArgumentException(nameof (mapper));

            _dataContext = dataContext ??
               throw new ArgumentNullException(nameof(dataContext));

            _dataSet = _dataContext.Set<Usuario>();
        }

        public async Task<UsuarioDbModel> ObterUsuarioAsync(Guid id)
        {
            var usuario = await _dataSet
                .AsNoTracking()
                .Include(i => i.Cliente).AsNoTracking()
                .Include(i => i.Operador).AsNoTracking()
                .SingleOrDefaultAsync(q => q.Id == id);

            return _mapper.Map<Usuario, UsuarioDbModel>(usuario);
        }

        public async Task<UsuarioDbModel> AutenticarUsuarioAsync(string login, string senha)
        {
            var usuario = await _dataSet
                .AsNoTracking()
                .Include(i => i.Cliente).AsNoTracking()
                .Include(i => i.Operador).AsNoTracking()
                .SingleOrDefaultAsync(q => (q.Cliente.Cpf == login || q.Operador.Matricula == login) 
                                            && q.Senha == senha);

            return _mapper.Map<Usuario, UsuarioDbModel>(usuario);
        }
        public async Task<UsuarioDbModel> CriarUsuarioAsync(UsuarioDbModel usuarioDbModel)
        {
            Usuario usuario = _mapper.Map<UsuarioDbModel, Usuario>(usuarioDbModel);

            await _dataSet.AddAsync(usuario);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Usuario, UsuarioDbModel>(usuario);
        }
    }
}