using AutoMapper;
using Pet.App.ViewModels;
using Pet.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //vamos transformar Fornecedor em FornecedorViewModel... caminho de mão unica..  para fazer o caminhi inverso adiciona .ReverseMap()
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }

    }
}
