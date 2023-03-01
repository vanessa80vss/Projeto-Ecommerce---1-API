using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ProjetoEcommerceAPI.Controllers.Models;
using ProjetoEcommerceAPI.Data;
using ProjetoEcommerceAPI.Data.Dtos.Categoria;
using ProjetoEcommerceAPI.Exceptions;
using ProjetoEcommerceAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoEcommerceAPI.Services
{
    public class CategoriaServices
    {
        private CategoriaRepository _categoriaRepository;
        private IMapper _mapper;
        public CategoriaServices(IMapper mapper, CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public ReadCategoriaDto CadastrarCategoria(CreateCategoriaDto categoriaDto)
        {
            Categoria categoriaNome = _categoriaRepository.PesquisarCategoriaPorNome(categoriaDto);

            if (categoriaDto.NomeDaCategoria.Length >= 3 && categoriaDto.NomeDaCategoria.Length <= 128)
            {
                if (categoriaNome == null)
                {
                    Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
                    categoria.StatusDaCategoria = true;
                    categoria.DataCriacao = DateTime.Now;
                    _categoriaRepository.CadastrarCategoria(categoria);
                    return _mapper.Map<ReadCategoriaDto>(categoria);
                }
                throw new ObjetoExistenteException("Categoria já existe");
            }
            throw new MinimoCaracteresException("Categoria precisa ter no minimo 3 letras e no máximo 128.");

        }

        public ReadCategoriaDto PesquisarCategoriaPorID(int id)
        {
            Categoria categoria = _categoriaRepository.PesquisarCategoriaPorId(id);

            if (categoria != null)
            {
                ReadCategoriaDto readDto = _mapper.Map<ReadCategoriaDto>(categoria);
                {
                    return readDto;
                }
            }
            return null;
        }

        public Result EditarCategoria(int id, UpDateCategoriaDto categoriaDto)
        {
            Categoria categoriaEditar = _categoriaRepository.PesquisarCategoriaPorId(id);

            if (categoriaEditar == null)
            {
                return Result.Fail("Categoria não existe");
            }
            _mapper.Map(categoriaDto, categoriaEditar);

            categoriaEditar.DataModificacao = DateTime.Now;
            _categoriaRepository.Salvar();
            return Result.Ok();
        }

        public Result DeletarCategoria(int id)
        {
            Categoria categoria = _categoriaRepository.PesquisarCategoriaPorId(id);
            if (categoria == null)
            {
                return Result.Fail("Id não encontrado");
            }
            _categoriaRepository.DeletarCategoria(categoria);
            return Result.Ok();

        }

        public IQueryable<Categoria> PesquisarComFiltros(string nome, bool? status, string ordem, int pagina, int quantidade)
        {
          return _categoriaRepository.PesquisarComFiltros(nome, status, ordem, pagina, quantidade);
        }

    }
}

        



