using System;
using System.Collections.Generic;
using System.Text;

namespace EL.FredericoRibeiro.Domain.Enums
{
    public enum ECombustivel : byte
    {
        Gasolina = 1,
        Alcool = 2,
        Diesel = 3
    }

    public enum ECategoria : byte
    {
        Basico = 1,
        Completo = 2,
        Luxo = 3
    }

    public class ERole
    {
        private ERole(string value) { Value = value; }

        public string Value { get; set; }

        public static ERole Operador { get { return new ERole("Operador"); } }
        public static ERole Cliente { get { return new ERole("Cliente"); } }
    }
}
