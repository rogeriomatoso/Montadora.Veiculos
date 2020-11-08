using Montadoras.Veiculos.Dominio;
using Montadoras.Veiculos.Generica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montadoras.Veiculos.Dados.Entity.TypeConfiguration
{
    class MontadoraTypeConfiguration : MontadoraEntityAbstractConfig<Montadora>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p =>p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema
                                            .DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Nome");

            Property(p => p.Nacionalidade)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Nacionalidade");

            Property(p => p.MercadoPaises)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnName("MercadoPaises");            

        }

        protected override void ConfigurarChaveEstrangeira()
        {
           
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("Montadora");
        }
    }
}
