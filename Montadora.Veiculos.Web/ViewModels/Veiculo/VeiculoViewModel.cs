using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Montadoras.Veiculos.Web.ViewModels.Veiculo
{
    public class VeiculoViewModel
    {
        [Required(ErrorMessage ="Id é obrigatorio...")]
        public long IdVeiculo { get; set; }


        [Display(Name = "Modelo do Veículo")]
        [Required(ErrorMessage ="Modelo deve ser preenchido!")]
        [MaxLength(100,ErrorMessage ="Quantida maxima de caracteres é 100.")]
        public string Modelo { get; set; }


        [Display(Name = "Ano do Modelo")]
        [Required(ErrorMessage = "O ano não pode ser vazio!")]       
        public int Ano { get; set; }


        [Display(Name = "Id da Montadora")]
        [Required(ErrorMessage = "Este campo não pode ficar vazio!")]        
        public int IdMontadora { get; set; }
    }
}