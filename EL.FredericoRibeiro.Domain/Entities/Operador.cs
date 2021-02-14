using EL.FredericoRibeiro.Domain.Core.Entities;
using EL.FredericoRibeiro.Domain.ValueObjects;
using Flunt.Validations;

namespace EL.FredericoRibeiro.Domain.Entities
{
    public class Operador : Entity, IAggregateRoot
    {
        /// <summary>
        /// Construtor para criação
        /// </summary>
        /// <param name="matricula"></param>
        /// <param name="nome"></param>
        public Operador(string matricula, 
            string nome)
        {
            Matricula = matricula;
            Nome = nome;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Matricula, nameof(Matricula), "Matrícula não pode ser nulo")
                .HasLen(Matricula, 6, nameof(Matricula), "Matrícula deve conter 6 caracteres"));
        }

        public string Matricula { get; private set; }
        public string Nome { get; private set; }
    }
}
