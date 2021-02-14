using EL.FredericoRibeiro.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.FredericoRibeiro.Application.Models
{
    public class UsuarioClienteInclusaoModel
    {
        public Guid ClienteId { get; set; }
        public string Senha { get; set; }

    }
}
