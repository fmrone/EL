using EL.FredericoRibeiro.Application.Models;
using EL.FredericoRibeiro.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace EL.FredericoRibeiro.Application.Interfaces
{
    public interface IUsuarioApplication
    {
        Task<Result<string>> CriarUsuarioCliente(UsuarioClienteInclusaoModel usuarioClienteInclusaoModel);
        Task<Result<string>> CriarUsuarioOperador(UsuarioOperadorInclusaoModel usuarioOperadorInclusaoModel);
    }
}