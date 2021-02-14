using EL.FredericoRibeiro.Infrastructure.Data.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EL.FredericoRibeiro.Infrastructure.Data.Entities
{
    public class Cliente : EntityBase
    {
        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }

        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required]
        public int Aniversario { get; set; }

        [Required]
        public int Cep { get; set; }

        [Required]
        [MaxLength(100)]
        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }

        [MaxLength(20)]
        public string Complemento { get; set; }

        [Required]
        [MaxLength(80)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(2)]
        public string Estado { get; set; }

        [ForeignKey("Usuario")]
        public Guid? UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
