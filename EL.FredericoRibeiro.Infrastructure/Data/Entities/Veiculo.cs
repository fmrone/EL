using EL.FredericoRibeiro.Infrastructure.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EL.FredericoRibeiro.Infrastructure.Data.Entities
{
    public class Veiculo : EntityBase
    {
        [Required]
        [StringLength(7)]
        public string Placa { get; set; }
        
        [Required]
        public int Ano { get; set; }
        
        [Required]
        public decimal ValorHora { get; set; }
        
        /// <summary>
        /// 1 - gasolina, 2 - álcool, 3 - diesel
        /// </summary>
        [Required]
        public byte Combustivel { get; set; }

        [Required]
        public decimal LimitePortaMalas { get; set; }

        /// <summary>
        /// 1 - básico, 2 - completo, 3 - luxo
        /// </summary>
        [Required]
        public byte Categoria { get; set; }

        [Required]
        [ForeignKey("ModeloId")]
        public Modelo Modelo { get; set; }
    }
}
