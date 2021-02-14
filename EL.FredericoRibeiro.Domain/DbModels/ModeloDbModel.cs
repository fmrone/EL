using System;
using System.Collections.Generic;

namespace EL.FredericoRibeiro.Domain.DbModels
{
    public class ModeloDbModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public MarcaDbModel MarcaDbModel { get; set; }

        public ICollection<VeiculoDbModel> VeiculosDbModel { get; set; }
    }
}
