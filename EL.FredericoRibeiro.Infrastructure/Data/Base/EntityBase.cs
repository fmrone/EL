using System;
using System.ComponentModel.DataAnnotations;

namespace EL.FredericoRibeiro.Infrastructure.Data.Base
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
