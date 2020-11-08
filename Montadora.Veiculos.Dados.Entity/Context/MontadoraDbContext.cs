using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Montadoras.Veiculos.Dados.Entity.TypeConfiguration;
using Montadoras.Veiculos.Dominio;

namespace Montadoras.Veiculos.Dados.Entity.Context
{
    public class MontadoraDbContext : DbContext
    {
        public DbSet<Montadora> Montadoras { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }


        public MontadoraDbContext()//construtor apenas para otimizar o processamento das migrations
                               //porém é dispensável.
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MontadoraTypeConfiguration());
            modelBuilder.Configurations.Add(new VeiculoTypeConfiguration());
        }
    }
}
