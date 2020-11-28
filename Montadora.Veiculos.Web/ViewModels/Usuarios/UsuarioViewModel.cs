using Montadoras.Veiculos.Web.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Montadoras.Veiculos.Web.ViewModels.Usuarios
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage="E-mail é obrigatório!")]
        [EmailAttribute(ErrorMessage = "Este dominio não é permitido!")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Preencha a Senha...")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}