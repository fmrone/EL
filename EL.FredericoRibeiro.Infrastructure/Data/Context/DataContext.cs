using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EL.FredericoRibeiro.Infrastructure.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Entities.Cliente> Cliente { get; set; }
        public DbSet<Entities.Marca> Marca { get; set; }
        public DbSet<Entities.Modelo> Modelo { get; set; }
        public DbSet<Entities.Operador> Operador { get; set; }
        public DbSet<Entities.Usuario> Usuario { get; set; }
        public DbSet<Entities.Veiculo> Veiculo { get; set; }

           
    }
}
