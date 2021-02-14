using AutoMapper;
using EL.FredericoRibeiro.Application.Models;
using EL.FredericoRibeiro.Domain.DbModels;
using EL.FredericoRibeiro.Domain.Entities;
using EL.FredericoRibeiro.Domain.ValueObjects;

namespace EL.FredericoRibeiro.Application.Mapping
{
    public class ClienteMap : Profile
    {
        public ClienteMap()
        {
            CreateMap<ClienteInclusaoModel, Cliente>()
                .ForMember(cliente => cliente.Nome, m => m.Ignore())
                .ForMember(cliente => cliente.Cpf, m => m.Ignore())
                .ForMember(cliente => cliente.Aniversario, m => m.Ignore())
                .ForMember(cliente => cliente.Cep, m => m.Ignore())
                .ForMember(cliente => cliente.Logradouro, m => m.Ignore())
                .ForMember(cliente => cliente.Numero, m => m.Ignore())
                .ForMember(cliente => cliente.Complemento, m => m.Ignore())
                .ForMember(cliente => cliente.Cidade, m => m.Ignore())
                .ForMember(cliente => cliente.Estado, m => m.Ignore())
                .ConstructUsing(clienteDbModel =>
                    new Cliente(clienteDbModel.Nome,
                        new CPF(clienteDbModel.Cpf),
                        clienteDbModel.Aniversario,
                        clienteDbModel.Cep,
                        clienteDbModel.Logradouro,
                        clienteDbModel.Numero,
                        clienteDbModel.Complemento,
                        clienteDbModel.Cidade,
                        clienteDbModel.Estado));

            CreateMap<Cliente, ClienteDbModel>();
            CreateMap<ClienteDbModel, ClienteModel>();
            CreateMap<Cliente, ClienteModel>();
        }
    }
}
