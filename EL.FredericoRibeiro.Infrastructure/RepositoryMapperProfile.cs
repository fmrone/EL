using AutoMapper;
using EL.FredericoRibeiro.Domain.DbModels;
using EL.FredericoRibeiro.Infrastructure.Data.Entities;

namespace EL.FredericoRibeiro.Infrastructure
{
    public class RepositoryMapperProfile : Profile
    {
        public RepositoryMapperProfile()
        {
            CreateMap<ClienteDbModel, Cliente>();
            CreateMap<Cliente, ClienteDbModel>();

            CreateMap<MarcaDbModel, Marca>();
            CreateMap<Marca, MarcaDbModel>();

            CreateMap<ModeloDbModel, Modelo>();
            CreateMap<Modelo, ModeloDbModel>();

            CreateMap<OperadorDbModel, Operador>();
            CreateMap<Operador, OperadorDbModel>();

            CreateMap<UsuarioDbModel, Usuario>();
            CreateMap<Usuario, UsuarioDbModel>();

            CreateMap<VeiculoDbModel, Veiculo>();
            CreateMap<Veiculo, VeiculoDbModel>();
        }
    }
}
