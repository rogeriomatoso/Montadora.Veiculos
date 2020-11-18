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
   public class VeiculosRepositorio : RepositorioGenericoEntity<Veiculo, long>
    {
        public VeiculosRepositorio(MontadoraDbContext contexto)
            : base(contexto)
        {
            
        }

        public override List<Veiculo> Selecionar()
        {
            return _contexto.Set<Veiculo>().Include(v => v.Montadora).ToList();
        }

        public override Veiculo SelecionarPorId(long id)
        {
            return _contexto.Set<Veiculo>().Include(v => v.Montadora)
                .SingleOrDefault(v => v.IdVeiculo == id);
        }
    }
}
