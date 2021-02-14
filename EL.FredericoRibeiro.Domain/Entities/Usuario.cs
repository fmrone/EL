using EL.FredericoRibeiro.Domain.Core.Entities;
using EL.FredericoRibeiro.Domain.Enums;
using Flunt.Validations;

namespace EL.FredericoRibeiro.Domain.Entities
{
    public class Usuario : Entity, IAggregateRoot
    {
        public Usuario(string senha, ERole role)
        {
            Senha = senha;
            Role = role;

            AddNotifications(new Contract()
               .Requires()
               .IsNotNull(Senha, nameof(Senha), "Senha não pode ser nula")
               .IsNotNull(Role, nameof(Role), "Role não pode ser nula"));
        }

        public string Senha { get; private set; }
        public ERole Role { get; private set; }
    }
}
