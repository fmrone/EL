using AutoMapper;
using EL.FredericoRibeiro.Application.Models;
using EL.FredericoRibeiro.Domain.DbModels;
using EL.FredericoRibeiro.Domain.Entities;
using EL.FredericoRibeiro.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.FredericoRibeiro.Application.Mapping
{
    public class UsuarioMap : Profile
    {
        public UsuarioMap()
        {
            CreateMap<UsuarioClienteInclusaoModel, Usuario>()
                .ForMember(to => to.Id, m => m.Ignore())
                .ForMember(to => to.Senha, m => m.Ignore())
                .ForMember(to => to.Role, m => m.Ignore())
                .ConstructUsing(usuarioClienteInclusaoModel =>
                    new Usuario(
                        usuarioClienteInclusaoModel.Senha,
                        ERole.Cliente));

            CreateMap<UsuarioOperadorInclusaoModel, Usuario>()
                .ForMember(usuario => usuario.Id, m => m.Ignore())
                .ForMember(usuario => usuario.Senha, m => m.Ignore())
                .ForMember(usuario => usuario.Role, m => m.Ignore())
                .ConstructUsing(usuarioOperadorInclusaoModel =>
                    new Usuario(
                        usuarioOperadorInclusaoModel.Senha,
                        ERole.Operador));

            CreateMap<Usuario, UsuarioDbModel>()
                 .ForMember(to => to.Id, m => m.MapFrom(from => from.Id))
                 .ForMember(to => to.Senha, m => m.MapFrom(from => from.Senha))
                 .ForMember(to => to.Role, m => m.MapFrom(from => from.Role.Value));
        }
    }
}
