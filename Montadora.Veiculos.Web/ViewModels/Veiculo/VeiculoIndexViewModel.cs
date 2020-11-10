using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Montadoras.Veiculos.Web.ViewModels.Veiculo
{
    public class VeiculoIndexViewModel
    {
        public long IdVeiculo { get; set; }

        [Display(Name = "Modelo do Veículo")]
        public string Modelo { get; set; }

        [Display(Name ="Ano do Modelo")]
        public int Ano { get; set; }

        [Display(Name ="Id da Montadora")]
        public int IdMontadora { get; set; }
    }
}