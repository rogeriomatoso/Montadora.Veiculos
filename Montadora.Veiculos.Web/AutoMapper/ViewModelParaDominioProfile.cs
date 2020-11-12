using AutoMapper;
using Montadoras.Veiculos.Dominio;
using Montadoras.Veiculos.Web.ViewModels.Montadora;
using Montadoras.Veiculos.Web.ViewModels.Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Montadoras.Veiculos.Web.AutoMapper
{
    public class ViewModelParaDominioProfile : Profile
    {
        protected override void Configure()

        {
            Mapper.CreateMap<MontadoraViewModel, Montadora>();
            Mapper.CreateMap<VeiculoViewModel, Veiculo>();
        }
    }
}