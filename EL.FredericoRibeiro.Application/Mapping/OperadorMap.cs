using AutoMapper;
using EL.FredericoRibeiro.Application.Models;
using EL.FredericoRibeiro.Domain.DbModels;
using EL.FredericoRibeiro.Domain.Entities;
using EL.FredericoRibeiro.Domain.ValueObjects;

namespace EL.FredericoRibeiro.Application.Mapping
{
    public class OperadorMap : Profile
    {
        public OperadorMap()
        {
            CreateMap<OperadorInclusaoModel, Operador>()
                .ForMember(to => to.Matricula, m => m.Ignore())
                .ForMember(to => to.Nome, m => m.Ignore())
                .ConstructUsing(from =>
                    new Operador(from.Matricula,
                        from.Nome));

            CreateMap<Operador, OperadorDbModel>();
            CreateMap<OperadorDbModel, OperadorModel>();
            CreateMap<Operador, OperadorModel>();
        }
    }
}
