using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pet.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pet.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto> //implementar a interface e configura no builder da mesma
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id); //chave primária

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Imagem)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("Produtos");
            //builder.ToTable("Produtos", "pet"); se houvesse um schema '.dbo' ou etc... poderia descrever assim
            //nao mapeamos as demais properties.. pois são decimal, bool e não precisam..

        }
    }
}
