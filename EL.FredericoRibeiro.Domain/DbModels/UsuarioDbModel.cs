using System;
using System.Collections.Generic;
using System.Text;

namespace EL.FredericoRibeiro.Domain.DbModels
{
    public class UsuarioDbModel
    {
        public Guid Id { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
    }
}
