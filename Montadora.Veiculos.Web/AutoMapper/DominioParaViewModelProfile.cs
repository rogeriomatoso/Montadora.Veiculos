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
    public class DominioParaViewModelProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Montadora, MontadoraIndexViewModel>()
                .ForMember(p=>p.Nome, opt =>
                {
                    opt.MapFrom(src => string.Format("{0}: {1}", src.Nome, src.Nacionalidade
                        .ToString()));
                });

            Mapper.CreateMap<Montadora, MontadoraViewModel>();


            Mapper.CreateMap<Veiculo, VeiculoIndexViewModel>()
                .ForMember(v => v.Modelo, opt =>
                {
                    opt.MapFrom(src => src.Montadora.Nome);
                });

            Mapper.CreateMap<Veiculo, VeiculoViewModel>();
        }
    }
}