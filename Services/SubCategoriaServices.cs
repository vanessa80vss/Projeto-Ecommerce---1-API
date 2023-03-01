using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ProjetoEcommerceAPI.Controllers.Models;
using ProjetoEcommerceAPI.Data;
using ProjetoEcommerceAPI.Data.Dtos.SubCategoria;
using ProjetoEcommerceAPI.Exceptions;
using ProjetoEcommerceAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoEcommerceAPI.Services
{
    public class SubCategoriaServices
    {
        private SubCategoriaRepository _subCategoriaRepository;
        private IMapper _mapper;
        public SubCategoriaServices(IMapper mapper, SubCategoriaRepository subCategoriaRepository)
        {
            _subCategoriaRepository = subCategoriaRepository;
            _mapper = mapper;
        }

        public ReadSubCategoriaDto CadastrarSubCategoria(CreateSubCategoriaDto subCategoriaDto)
        {
            SubCategoria subCategoriaNome = _subCategoriaRepository.PesquisarSubCategoriaPorNome(subCategoriaDto);

            if (subCategoriaDto.NomeDaSubCategoria.Length >= 3 && subCategoriaDto.NomeDaSubCategoria.Length <= 128)
            {
                if (subCategoriaNome == null)
                {
                    SubCategoria subCategoria = _mapper.Map<SubCategoria>(subCategoriaDto);
                    subCategoria.StatusDaSubCategoria = true;
                    subCategoria.DataCriacao = DateTime.Now;
                    _subCategoriaRepository.CadastrarSubCategoria(subCategoria);
                    return _mapper.Map<ReadSubCategoriaDto>(subCategoria);
                }
                throw new ObjetoExistenteException("SubCategoria já existe");
            }
            throw new MinimoCaracteresException("SubCategoria precisa ter no minimo 3 letras e no máximo 128.");

        }

        public ReadSubCategoriaDto PesquisarSubCategoriaPorID(int id)
        {
           SubCategoria subCategoria = _subCategoriaRepository.PesquisarSubCategoriaPorId(id);

            if (subCategoria != null)
            {
                ReadSubCategoriaDto readSubDto = _mapper.Map<ReadSubCategoriaDto>(subCategoria);
                {
                    return readSubDto;
                }
            }
            return null;
        }

        public Result EditarSubCategoria(int id, UpDateSubCategoriaDto subCategoriaDto)
        {
            SubCategoria subCategoriaEditar = _subCategoriaRepository.PesquisarSubCategoriaPorId(id);

            if (subCategoriaEditar == null)
            {
                return Result.Fail("SubCategoria não existe");
            }
            _mapper.Map(subCategoriaDto, subCategoriaEditar);

            subCategoriaEditar.DataModificacao = DateTime.Now;
            _subCategoriaRepository.Salvar();
            return Result.Ok();
        }

        public Result DeletarSubCategoria(int id)
        {
            SubCategoria subCategoria = _subCategoriaRepository.PesquisarSubCategoriaPorId(id);
            if (subCategoria == null)
            {
                return Result.Fail("Id não encontrado");
            }
            _subCategoriaRepository.DeletarSubCategoria(subCategoria);
            return Result.Ok();

        }

        public IQueryable<SubCategoria> PesquisarSubCategoriaComFiltros(string nome, bool? status, string ordem, int pagina, int quantidade)
        {
            return _subCategoriaRepository.PesquisarSubCategoriaComFiltros(nome, status, ordem, pagina, quantidade);
        }

    }
}
