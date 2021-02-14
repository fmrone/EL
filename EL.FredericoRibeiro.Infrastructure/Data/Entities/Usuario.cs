using EL.FredericoRibeiro.Infrastructure.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EL.FredericoRibeiro.Infrastructure.Data.Entities
{
    public class Usuario : EntityBase
    {
        [Required]
        public string Senha { get; set; }

        [Required]
        public string Role { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Operador Operador { get; set; }

        /*
        [ForeignKey("OperadorId")]
        public virtual Operador Operador { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
        */
    }
}
