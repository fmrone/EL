using EL.FredericoRibeiro.Infrastructure.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EL.FredericoRibeiro.Infrastructure.Data.Entities
{
    public class Operador : EntityBase
    {
        [Required]
        [StringLength(6)] 
        public string Matricula { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }

        [ForeignKey("Usuario")]
        public Guid? UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
