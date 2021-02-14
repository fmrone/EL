using AutoMapper;
using EL.FredericoRibeiro.Application.Interfaces;
using EL.FredericoRibeiro.Application.Models;
using EL.FredericoRibeiro.Domain.DbModels;
using EL.FredericoRibeiro.Domain.Entities;
using EL.FredericoRibeiro.Domain.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EL.FredericoRibeiro.Application
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioWriteOnlyRepository _usuarioWriteOnlyRepository;
        private readonly IClienteReadOnlyRepository _clienteReadOnlyRepository;
        private readonly IClienteWriteOnlyRepository _clienteWriteOnlyRepository;
        private readonly IOperadorReadOnlyRepository _operadorReadOnlyRepository;
        private readonly IOperadorWriteOnlyRepository _operadorWriteOnlyRepository;

        public UsuarioApplication(IMapper mapper,
            IUsuarioWriteOnlyRepository usuarioWriteOnlyRepository,
            IClienteReadOnlyRepository clienteReadOnlyRepository,
            IClienteWriteOnlyRepository clienteWriteOnlyRepository,
            IOperadorReadOnlyRepository operadorReadOnlyRepository,
            IOperadorWriteOnlyRepository operadorWriteOnlyRepository

            )
        {
            _mapper = mapper;
            _usuarioWriteOnlyRepository = usuarioWriteOnlyRepository;
            _clienteReadOnlyRepository = clienteReadOnlyRepository;
            _clienteWriteOnlyRepository = clienteWriteOnlyRepository;
            _operadorReadOnlyRepository = operadorReadOnlyRepository;
            _operadorWriteOnlyRepository = operadorWriteOnlyRepository;
        }

        public async Task<Result<string>> CriarUsuarioCliente(UsuarioClienteInclusaoModel usuarioClienteInclusaoModel)
        {
            var usuario = _mapper.Map<UsuarioClienteInclusaoModel, Usuario>(usuarioClienteInclusaoModel);
            if (!usuario.Valid)
                return Result<string>.Error(usuario.Notifications);

            var clienteDbModel = await _clienteReadOnlyRepository.ObterClienteAsync(usuarioClienteInclusaoModel.ClienteId);
            if (clienteDbModel == null)
                return Result<string>.Error(new List<Notification>
                {
                    new Notification("Usuário", "Cliente não encontrado")
                });

            var usuarioDbModel = await _usuarioWriteOnlyRepository
                .CriarUsuarioAsync(_mapper.Map<Usuario, UsuarioDbModel>(usuario));

            if (usuarioDbModel != null)
                await _clienteWriteOnlyRepository
                    .AtribuirUsuario(clienteDbModel.Id, usuarioDbModel.Id);

            return Result<string>.Ok(usuario.Id.ToString());
        }

        public async Task<Result<string>> CriarUsuarioOperador(UsuarioOperadorInclusaoModel usuarioOperadorInclusaoModel)
        {
            var usuario = _mapper.Map<UsuarioOperadorInclusaoModel, Usuario>(usuarioOperadorInclusaoModel);
            if (!usuario.Valid)
                return Result<string>.Error(usuario.Notifications);

            var operadorDbModel = await _operadorReadOnlyRepository.ObterOperadorAsync(usuarioOperadorInclusaoModel.OperadorId);
            if (operadorDbModel == null)
                return Result<string>.Error(new List<Notification>
                {
                    new Notification("Usuário", "Operador não encontrado")
                });

            var usuarioDbModel = await _usuarioWriteOnlyRepository
                .CriarUsuarioAsync(_mapper.Map<Usuario, UsuarioDbModel>(usuario));

            if (usuarioDbModel != null)
                await _operadorWriteOnlyRepository
                    .AtribuirUsuario(operadorDbModel.Id, usuarioDbModel.Id);

            return Result<string>.Ok(usuario.Id.ToString());
        }
    }
}
