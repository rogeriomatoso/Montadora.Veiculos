using Montadoras.Repositorios.Comum.Entity;
using Montadoras.Veiculos.Dados.Entity.Context;
using Montadoras.Veiculos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Montadoras.Veiculos.Repositorios.Entity
{
   public class MontadorasRepositorio : RepositorioGenericoEntity<Montadora, int>
    {
        public MontadorasRepositorio(MontadoraDbContext contexto)
            : base(contexto)
        {

        }

        public override List<Montadora> Selecionar()
        {
            //essa linha é equivalente a um join no banco de dados
            return _contexto.Set<Montadora>().Include(m => m.Veiculos).ToList();
        }

        public override Montadora SelecionarPorId(int id)
        {
            return _contexto.Set<Montadora>().Include(p => p.Veiculos)
                //aqui equivale a um where no BD
                .SingleOrDefault(m => m.Id == id);
        }
    }
}
