using Microsoft.EntityFrameworkCore;
using Pet.Business.Interface;
using Pet.Business.Models;
using Pet.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDBContext context) : base(context)
        {
        }

        //retorna um produto e o fornecedor dele.. 
        //vai na tabela produto, faz um join com FOrnecedor, onde o produto tem o id passado
        //pega o dbcontext, produtos q é a tabela.. incluir um fornecedor, (pega os dados de produto e faz inner join com fornecedor)
        //firstorrdefault para pegar apenas um onde o id do produto é igual ao id passado ali..
        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        //Obter todos os produtos com os dados do Fornecedor desses produtos, organizando pelo nome do produto
        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        //Filtrar o Fornecedor da lista ded produtos
        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}
