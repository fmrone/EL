using System;

namespace EL.FredericoRibeiro.Domain.DbModels
{
    public class VeiculoDbModel
    {
        public Guid Id { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public decimal ValorHora { get; set; }
        /// <summary>
        /// 1 - gasolina, 2 - álcool, 3 - diesel
        /// </summary>
        public byte Combustivel { get; set; }
        public decimal LimitePortaMalas { get; set; }
        /// <summary>
        /// 1 - básico, 2 - completo, 3 - luxo
        /// </summary>
        public byte Categoria { get; set; }
        public ModeloDbModel ModeloDbModel { get; set; }
    }
}
