using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pet.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pet.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            //1 : 1 => FOrnecedor : Endereco
            builder.HasOne(f => f.Endereco)   //Fornecedor tem um endereco
                .WithOne(e => e.Fornecedor);  //Endereco tem um Fornecedor

            //1 : N => Fornecedor : Produtos
            builder.HasMany(f => f.Produtos) //Fornecedor possui muitos produtos
                .WithOne(p => p.Fornecedor)  //Um produto possui um fornecedor
                .HasForeignKey(p => p.FornecedorId); //chave estrangeira

            //**** A Classe que possui as outras filhas que configura o mapeamento

            builder.ToTable("Fornecedores");
        }
    }
}
