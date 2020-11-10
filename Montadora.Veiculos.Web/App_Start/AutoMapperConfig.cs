using AutoMapper;
using Montadoras.Veiculos.Web.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Montadoras.Veiculos.Web.App_Start
{
    public static class AutoMapperConfig 
    {
        public static void Configurar()
        {
            Mapper.AddProfile < DominioParaViewModelProfile>();
        }
    }
}