using Pet.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Business.Interface
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId); //lista de produtos por fornecedor
        Task<IEnumerable<Produto>> ObterProdutosFornecedores(); //lista de produtos e fornecedores
        Task<Produto> ObterProdutoFornecedor(Guid id); //retorna um produto e fornecedor
    }
}
