using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montadoras.Veiculos.Dominio
{
    public class Veiculo
    {
        public long IdVeiculo { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public virtual Montadora Montadora { get; set; }
        public int IdMontadora { get; set; }
    }
}
