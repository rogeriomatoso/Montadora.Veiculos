using Montadoras.Veiculos.Dominio;
using Montadoras.Veiculos.Generica.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montadoras.Veiculos.Dados.Entity.TypeConfiguration
{
    class VeiculoTypeConfiguration : MontadoraEntityAbstractConfig<Veiculo>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.IdVeiculo)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations
                                            .Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("IdVeiculo");

            Property(p => p.Modelo)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Modelo");

            Property(p => p.Ano)
                .IsRequired()
                .HasColumnName("Modelo - Ano");

            Property(p => p.IdMontadora)
                .IsRequired()
                .HasColumnName("Id Montadora");

        }

        protected override void ConfigurarChaveEstrangeira()
        {
            HasRequired(p => p.Montadora)
                .WithMany(p => p.Veiculos)
                .HasForeignKey(fk => fk.IdMontadora);
        }

        protected override void ConfigurarChavePrimaria()
        {
           HasKey(pk => pk.IdVeiculo);
        }

        protected override void ConfigurarNomeTabela()
        {
           ToTable("Veiculo");
        }
    }
}
