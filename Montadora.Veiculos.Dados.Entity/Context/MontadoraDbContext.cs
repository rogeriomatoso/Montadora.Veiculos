using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Montadoras.Veiculos.Dominio;

namespace Montadoras.Veiculos.Dados.Entity.Context
{
    public class MontadoraDbContext : DbContext
    {
        public DbSet<Montadora> Montadoras { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
