using Pet.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Business.Interface
{
    //repositório genérico, fornece metodos necessarios para qualquer entidade
    //TEntity nome escolhido.. IDisposable para obrigar que o repositorio libere a memoria... where TEntity p/ q só possa ser utilizada se for filha de Entity
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity); //quando temos apenas task.. metodo void, nao retorna nada

        Task<TEntity> ObterPorId(Guid id); //retornando a propria entidade
        Task<List<TEntity>> ObterTodos(); //retornando uma lista da entidade
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);

        //passa Expression(linq.expression)lambda que vai trabalhar com uma Function que vai comparar a sua entidade com alguma coisa desde q ela retorne um boolean.
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);


        Task<int> SaveChanges();
    }
}
