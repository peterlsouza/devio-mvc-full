using Microsoft.EntityFrameworkCore;
using Pet.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pet.Data.Context
{
    public class MeuDBContext : DbContext
    {
        public MeuDBContext(DbContextOptions<MeuDBContext> options) : base(options)
        {
            //esse comando abaixo não estava na aula.. Pires passou via suporte
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        //Para mapear o tamanho de coluna, tipo campos etc.. vamos usar o FluentAPI para nao poluir as entidades com Data Annotations
        //Para isso usamos os Mappings.. 

        //para criar as migrations: Add-Migration Initial -Context MeuDBContext -Verbose
        //Update-Database -Context MeuDBContext -Verbose

        //Para gerar script SQL Server: Script-Migration -Context MeuDBContext -Verbose

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //garantia para criar os campos com varchar 100 caso esquecermos de informar algum tipo em alguma coluna
            //no .net 2 usado pelo Pires na aula era diferente..
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            
            //Config para registrar cada um dos mappings.. feito via reflection
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDBContext).Assembly);

            //impedir que uma classe ao excluir um item, leve o filhos juntos.. drop cascade
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany
                (e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}