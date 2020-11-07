using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montadoras.Veiculos.Dominio
{
    public class Montadora
    {
        public int Id {get;set;}
        public string Nome { get; set;}
        public string Nacionalidade { get; set; }
        public string MercadoPaises { get; set; }
        public virtual List<Veiculo> Veiculos { get; set; }
    }
}
