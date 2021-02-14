using System;
using System.Collections.Generic;
using System.Text;

namespace EL.FredericoRibeiro.Application.Models
{
    public class ClienteInclusaoModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Aniversario { get; set; }
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
