using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Montadoras.Veiculos.Web.Annotations
{
    public class CNPJMontadoraAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string cnpjMontadora = Convert.ToString(value);
            if (cnpjMontadora.Length != 14)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    
       
}