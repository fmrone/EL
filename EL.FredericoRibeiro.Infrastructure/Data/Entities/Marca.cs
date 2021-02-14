using EL.FredericoRibeiro.Infrastructure.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EL.FredericoRibeiro.Infrastructure.Data.Entities
{
    public class Marca : EntityBase
    {
        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }

        public virtual ICollection<Modelo> Modelos { get; set; }
    }
}
