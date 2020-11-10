using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Montadoras.Veiculos.Web.ViewModels.Montadora
{
    public class MontadoraIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome da Montadora")]
        public string Nome { get; set; }

        [Display(Name = "Nacionalidade da Montadora")]
        public string Nacionalidade { get; set; }

        [Display(Name = "Mercados onde Atua")]
        public string MercadoPaises { get; set; }
    }
}