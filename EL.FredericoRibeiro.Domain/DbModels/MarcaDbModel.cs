using System;
using System.Collections.Generic;

namespace EL.FredericoRibeiro.Domain.DbModels
{
    public class MarcaDbModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public ICollection<ModeloDbModel> ModelosDbModel { get; set; }
    }
}
