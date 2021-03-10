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
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository //implementa o : Repository especializado para <Fornecedor>
    {
        public FornecedorRepository(MeuDBContext context) : base(context)
        { 
        }

        //Obter Fornecedor e Endereço
        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(c => c.Produtos)
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }


    }
}
