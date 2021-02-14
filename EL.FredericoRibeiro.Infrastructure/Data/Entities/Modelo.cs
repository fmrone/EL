using EL.FredericoRibeiro.Infrastructure.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EL.FredericoRibeiro.Infrastructure.Data.Entities
{
    public class Modelo : EntityBase
    {
        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }

        [Required]
        [ForeignKey("MarcaId")]
        public virtual Marca Marca { get; set; }

        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}
