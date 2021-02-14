using EL.FredericoRibeiro.Domain.Core.Entities;
using EL.FredericoRibeiro.Domain.ValueObjects;
using Flunt.Validations;

namespace EL.FredericoRibeiro.Domain.Entities
{
    public class Cliente : Entity, IAggregateRoot
    {
        /// <summary>
        /// Construtor para criação
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="cpf"></param>
        /// <param name="aniversario"></param>
        /// <param name="cep"></param>
        /// <param name="logradouro"></param>
        /// <param name="numero"></param>
        /// <param name="complemento"></param>
        /// <param name="cidade"></param>
        /// <param name="estado"></param>
        public Cliente(string nome, 
            CPF cpf, 
            int aniversario, 
            int cep, 
            string logradouro, 
            int numero, 
            string complemento, 
            string cidade, 
            string estado)
        {
            Nome = nome;
            Cpf = cpf;
            Aniversario = aniversario;
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado.ToUpper();

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Nome, nameof(Nome), "Nome não pode ser nulo")
                .IsNotNull(Cpf, nameof(Cpf), "Cpf não pode ser nulo")
                .IsNotNull(Logradouro, nameof(Logradouro), "Logradouro não pode ser nulo")
                .IsNotNull(Cidade, nameof(Cidade), "Cidade não pode ser nula")
                .IsNotNull(Estado, nameof(Estado), "Estado não pode ser nulo")
                .HasLen(Estado, 2, nameof(Estado), "Estado deve conter 2 caracteres"));

            ValidaAniversario();
        }

        private void ValidaAniversario()
        {
            string aniversario = Aniversario.ToString();
            if (aniversario.Length != 4)
                AddNotification(nameof(Aniversario), $"Aniversário com valor inválido. Informe um dia/mês válido");

            if (aniversario.Length == 4 && int.TryParse(aniversario.Substring(0, 2), out int dia))
                if (dia > 31 && dia < 1)
                    AddNotification(nameof(Aniversario), $"Dia do aniversário com valor inválido. Informe um dia/mês válido");

            if (aniversario.Length == 4 && int.TryParse(aniversario.Substring(2), out int mes))
                if (mes > 12 && mes < 1 )
                    AddNotification(nameof(Aniversario), $"Mes do aniversário com valor inválido. Informe um dia/mês válido");
        }

        public string Nome { get; private set; }
        public CPF Cpf { get; private set; }
        public int Aniversario { get; private set; }
        public int Cep { get; private set; }
        public string Logradouro { get; private set; }
        public int Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
    }
}
