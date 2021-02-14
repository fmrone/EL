using EL.FredericoRibeiro.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.FredericoRibeiro.Application.Models
{
    public class UsuarioOperadorInclusaoModel
    {
        public Guid OperadorId { get; set; }
        public string Senha { get; set; }
    }
}
