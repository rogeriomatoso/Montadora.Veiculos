using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Montadoras.Veiculos.Web.ViewModels.Montadora
{
    public class MontadoraViewModel
    {
        [Required(ErrorMessage ="Id é obrigatorio...")]
        public int Id { get; set; }

        [Display(Name = "Nome da Montadora")]
        [Required(ErrorMessage ="O nome da Montadora é indispensável.")]
        [MaxLength(100, ErrorMessage ="Nome deve conter o maximo de 100 caracteres!")]
        public string Nome { get; set; }

        [Display(Name = "Nacionalidade da Montadora")]
        [Required(ErrorMessage = "A nacionalidade é obrigatoria.")]
        [MaxLength(100, ErrorMessage = "Nacionalidade deve conter o maximo de 100 caracteres!")]
        public string Nacionalidade { get; set; }

        [Display(Name = "Mercados onde Atua")]
        [Required(ErrorMessage = "Este campo não pode ficar em branco.")]
        [MaxLength(300, ErrorMessage = "Este campo pode  conter um maximo de 100 caracteres!")]
        public string MercadoPaises { get; set; }
    }
}