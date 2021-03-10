using Microsoft.EntityFrameworkCore;
using Pet.Business.Interface;
using Pet.Business.Models;
using Pet.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new() //new() usado no Remove 
    {
        protected readonly MeuDBContext Db;
        
        protected readonly DbSet<TEntity> DbSet; //atalho para o DbSet
                   //Db.Set<TEntity>().Add(entity); //sem atalho
                   //DbSet.Add(entity); //com atalho
        //return sempre será await quando o metodo for async, await espera o resultado acontecer, converte a task para o resultado esperado
        //AsNoTracking -> para melhor performance.. nao vai rastrear todo o estado do objeto
        //virtual em alguns métodos para se necessario sobreescrever

        protected Repository(MeuDBContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            //vai até o banco de dados p/ entidade especifica, onde a expressão q passar retorna uma lista de forma assincrona
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync(); //AsNoTracking para consulta, otimiza performance
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            //Db.Set<TEntity>().Add(entity); //sem atalho
            DbSet.Add(entity); //com atalho
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id }); //passando a instancia...
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose(); //se existir, faz o dispose
        }
    }
}
