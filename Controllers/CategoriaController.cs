using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ProjetoEcommerceAPI.Controllers.Models;
using ProjetoEcommerceAPI.Data;
using ProjetoEcommerceAPI.Data.Dtos.Categoria;
using ProjetoEcommerceAPI.Exceptions;
using ProjetoEcommerceAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoEcommerceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private CategoriaServices _categoriaServices;

        public CategoriaController(CategoriaServices categoriaServices)
        {
            _categoriaServices = categoriaServices;
        }

        [HttpPost]
        public IActionResult CadastrarCategoria(CreateCategoriaDto categoriaDto)
        {
            try
            {
                ReadCategoriaDto readDto = _categoriaServices.CadastrarCategoria(categoriaDto);

                return CreatedAtAction(nameof(PesquisarCategoriaPorID), new { Id = readDto.Id }, readDto);
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
        //[HttpGet]
        //public IEnumerable<Categoria> RecuperarCategoria()
        //{
        //    return _context.Categorias;
        //}

        [HttpGet("{id}")]
        public IActionResult PesquisarCategoriaPorID(int id)
        {
            ReadCategoriaDto categoriaDto = _categoriaServices.PesquisarCategoriaPorID(id);
            if (categoriaDto != null) return Ok(categoriaDto);
            return NotFound("Não existe");
        }

        [HttpGet]
        public IActionResult PesquisarComFiltro([FromQuery] string nome, [FromQuery] bool? status, [FromQuery] string ordem, [FromQuery] int pagina, [FromQuery] int quantidade)
        {
            IQueryable<Categoria> PesquisaDeCategorias = _categoriaServices.PesquisarComFiltros(nome, status, ordem, pagina, quantidade);
            return Ok(PesquisaDeCategorias);
        }


        [HttpPut("{id}")]
        public IActionResult EditarCategoria(int id, [FromBody] UpDateCategoriaDto categoriaUpDateDto)
        {
            Result ResultadoEditarCategoria = _categoriaServices.EditarCategoria(id, categoriaUpDateDto);
            if (ResultadoEditarCategoria == null) return NotFound();
            return NoContent();


        }

        [HttpDelete("{id}")]

        public IActionResult DeletarCategoria(int id)
        {
            Result ResultadoDaExclusao = _categoriaServices.DeletarCategoria(id);

            if (ResultadoDaExclusao.IsFailed)  return NotFound();
            return NoContent();
        }

    }
}






//IQueryable<Categoria> lista = null;
//if (nome != null)
//{
//    lista = _context.Categorias.Where(c => c.NomeDaCategoria.ToLower().Contains(nome.ToLower()));
//}
//else
//{
//    lista = _context.Categorias;
//}
//if (status != null)
//{
//    if (status != true && status != false)
//    {
//        return NotFound("Favor digitar true ou false");
//    }
//    lista = lista.Where(c => c.StatusDaCategoria == status);
//}
//if (ordem != null)
//{
//    if (ordem.ToLower() != "desc" && ordem.ToLower() != "asc")
//    {
//        return NotFound("Favor digitar Desc para ordem decrescente e Asc para ordem crescente");
//    }
//    if (ordem.ToLower() == "desc")
//    {
//        lista = lista.OrderByDescending(c => c.NomeDaCategoria);
//    }
//    else if (ordem.ToLower() == "asc")
//    {
//        lista = lista.OrderBy(c => c.NomeDaCategoria);
//    }

//    if (quantidade > 0 && pagina > 0)
//    {
//        var resultado = lista.Skip((pagina - 1) * quantidade).Take(quantidade).ToList();
//    }

//}
//return Ok(lista);


//using Microsoft.AspNetCore.Mvc;
//using ProjetoAPI.Data.Dtos.CategoriaDto;
//using ProjetoAPI.Services;

//namespace ProjetoAPI.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class CategoriaController : ControllerBase
//    {
//        private CategoriaService categoriaService;
//        public CategoriaController(CategoriaService categoriaService)
//        {
//            this.categoriaService = categoriaService;
//        }
//        [HttpPost]
//        public IActionResult CadastrarCategorias([FromBody] CreateCategoriaDto categoriaDto)
//        {
//            var resultado = categoriaService.AddCategoria(categoriaDto);
//            if (resultado == null) return BadRequest("Nome deve ser maior que 3 caracteres e menor que 128." +
//                "\nImpossível cadastrar categoria com status inativo.");
//            return CreatedAtAction(nameof(PesquisaCategoria), new { nome = categoriaDto.Nome }, categoriaDto);
//        }
//        [HttpGet("buscar")]
//        public IActionResult PesquisaCategoria([FromQuery] string nome, [FromQuery] bool? status, [FromQuery] string ordem)
//        {
//            var resultado = categoriaService.PesquisaCategoria(nome, status, ordem);
//            if (resultado == null) return BadRequest("Favor digitar mais de 3 caracteres.");
//            return Ok(resultado);
//        }
//        [HttpPut("editar/{id}")]
//        public IActionResult EditarCategoria(int id, [FromBody] UpdateCategoriaDto novoNomeDto)
//        {
//            var resultado = categoriaService.EditarCategoria(id, novoNomeDto);
//            if (resultado == false) return BadRequest("Categoria não existe.");
//            return Ok("Editado com sucesso.");
//        }
//        [HttpDelete("{id}")]
//        public IActionResult DeletaCategoria(int id)
//        {
//            var resultado = categoriaService.DeletaCategoria(id);
//            if (resultado == false) return NotFound("Erro ao deletar.");
//            return Ok("Deletado com sucesso.");
//        }
//    }
//}