using Montadoras.Repositorios.Comum.Entity;
using Montadoras.Veiculos.Dados.Entity.Context;
using Montadoras.Veiculos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montadoras.Veiculos.Repositorios.Entity
{
   public class MontadorasRepositorio : RepositorioGenericoEntity<Montadora, int>
    {
        public MontadorasRepositorio(MontadoraDbContext contexto)
            : base(contexto)
        {

        }
    }
}
