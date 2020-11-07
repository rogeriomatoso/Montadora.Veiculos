using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montadora.Veiculos.Dominio
{
    public class Veiculo
    {
        public long IdVeiculo { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public virtual Montadora montadora { get; set; }
        public int IdMontadora { get; set; }
    }
}
