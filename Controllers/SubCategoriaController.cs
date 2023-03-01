using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ProjetoEcommerceAPI.Controllers.Models;
using ProjetoEcommerceAPI.Data;
using ProjetoEcommerceAPI.Data.Dtos.Categoria;
using ProjetoEcommerceAPI.Data.Dtos.SubCategoria;
using ProjetoEcommerceAPI.Exceptions;
using ProjetoEcommerceAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoEcommerceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubCategoriaController : ControllerBase
    {
        private SubCategoriaServices _subCategoriaServices;

        public SubCategoriaController(SubCategoriaServices subCategoriaServices)
        {
            _subCategoriaServices = subCategoriaServices;
        }

        [HttpPost]
        public IActionResult CadastrarSubCategoria(CreateSubCategoriaDto subCategoriaDto)
        {
            try
            {
                ReadSubCategoriaDto readSubDto = _subCategoriaServices.CadastrarSubCategoria(subCategoriaDto);

                return CreatedAtAction(nameof(PesquisarSubCategoriaPorID), new { Id = readSubDto.Id }, readSubDto);
            }
            catch (ObjetoExistenteException e)
            {
                return BadRequest(e.Message);
            }
            catch (MinimoCaracteresException e)
            {
                return BadRequest(e.Message);
            }
        }
        

        [HttpGet("{id}")]
        public IActionResult PesquisarSubCategoriaPorID(int id)
        {
            ReadSubCategoriaDto subCategoriaDto = _subCategoriaServices.PesquisarSubCategoriaPorID(id);
            if (subCategoriaDto != null) return Ok(subCategoriaDto);
            return NotFound("Não existe");
        }

        [HttpGet]
        public IActionResult PesquisarSubCategoriaComFiltro([FromQuery] string nome, [FromQuery] bool? status, [FromQuery] string ordem, [FromQuery] int pagina, [FromQuery] int quantidade)
        {
            IQueryable<SubCategoria> PesquisaDeSubCategorias = _subCategoriaServices.PesquisarSubCategoriaComFiltros(nome, status, ordem, pagina, quantidade);
            return Ok(PesquisaDeSubCategorias);
        }


        [HttpPut("{id}")]
        public IActionResult EditarSubCategoria(int id, [FromBody] UpDateSubCategoriaDto subCategoriaUpDateDto)
        {
            Result ResultadoEditarSubCategoria = _subCategoriaServices.EditarSubCategoria(id, subCategoriaUpDateDto);
            if (ResultadoEditarSubCategoria == null) return NotFound();
            return NoContent();


        }

        [HttpDelete("{id}")]

        public IActionResult DeletarSubCategoria(int id)
        {
            Result ResultadoDaExclusaoSubCategoria = _subCategoriaServices.DeletarSubCategoria(id);

            if (ResultadoDaExclusaoSubCategoria.IsFailed) return NotFound();
            return NoContent();
        }

    }
}
