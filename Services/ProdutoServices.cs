using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ProjetoEcommerceAPI.Controllers.Models;
using ProjetoEcommerceAPI.Data;
using ProjetoEcommerceAPI.Data.Dtos.Categoria;
using ProjetoEcommerceAPI.Data.Dtos.Produto;
using ProjetoEcommerceAPI.Exceptions;
using ProjetoEcommerceAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoEcommerceAPI.Services
{
    public class ProdutoServices
    {
        private ProdutoRepository _produtoRepository;
        private IMapper _mapper;

        public ProdutoServices(ProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }
    
        public ReadProdutoDto CadastrarProduto(CreateProdutoDto produtoDto)
        {
            Produto produtoNome = _produtoRepository.PesquisarProdutoPorNome(produtoDto);

            if (produtoDto.NomeDoProduto.Length >= 3 && produtoDto.NomeDoProduto.Length <= 128)
            {
                if (produtoNome == null)
                {
                    Produto produto = _mapper.Map<Produto>(produtoDto);
                    produto.StatusDoProduto = true;
                    produto.DataCriacaoDoProduto = DateTime.Now;
                    _produtoRepository.CadastrarProduto(produto);
                    return _mapper.Map<ReadProdutoDto>(produto);
                }
                throw new ObjetoExistenteException("Produto já existe");
            }
            throw new MinimoCaracteresException("produto precisa ter no minimo 3 letras e no máximo 128.");

        }

        public ReadProdutoDto PesquisarProdutoPorID(int id)
        {
            Produto produto = _produtoRepository.PesquisarProdutoPorId(id);

            if (produto != null)
            {
                ReadProdutoDto readProdutoDto = _mapper.Map<ReadProdutoDto>(produto);
                {
                    return readProdutoDto;
                }
            }
            return null;
        }

        public Result EditarProduto(int id, UpDateProdutoDto produtoDto)
        {
            Produto produtoEditar = _produtoRepository.PesquisarProdutoPorId(id);

            if (produtoEditar == null)
            {
                return Result.Fail("produto não existe");
            }
            _mapper.Map(produtoDto, produtoEditar);

            produtoEditar.DataModificacaoDoProduto = DateTime.Now;
            _produtoRepository.Salvar();
            return Result.Ok();
        }

        public Result DeletarProduto(int id)
        {
            Produto produto = _produtoRepository.PesquisarProdutoPorId(id);
            if (produto == null)
            {
                return Result.Fail("Id não encontrado");
            }
            _produtoRepository.DeletarProduto(produto);
            return Result.Ok();

        }

        public IQueryable<Produto> PesquisarProdutoComFiltros(string nome, bool? status, string ordem, int pagina, int quantidade)
        {
            return _produtoRepository.PesquisarProdutoComFiltros(nome, status, ordem, pagina, quantidade);
        }

    }
}
