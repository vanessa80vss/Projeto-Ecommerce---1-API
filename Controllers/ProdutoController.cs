using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ProjetoEcommerceAPI.Controllers.Models;
using ProjetoEcommerceAPI.Data.Dtos.Produto;
using ProjetoEcommerceAPI.Exceptions;
using ProjetoEcommerceAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoEcommerceAPI.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class ProdutoController : ControllerBase
        {
            private ProdutoServices _produtoServices;

            public ProdutoController(ProdutoServices produtoServices)
            {
              _produtoServices = produtoServices;
            }

            [HttpPost]
            public IActionResult CadastrarProduto(CreateProdutoDto produtoDto)
            {
                try
                {
                ReadProdutoDto readProdutoDto = _produtoServices.CadastrarProduto(produtoDto);

                    return CreatedAtAction(nameof(PesquisarProdutoPorID), new { Id = readProdutoDto.ProdutoId }, readProdutoDto);
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
            public IActionResult PesquisarProdutoPorID(int id)
            {
                ReadProdutoDto produtoDto = _produtoServices.PesquisarProdutoPorID(id);
                if (produtoDto != null) return Ok(produtoDto);
                return NotFound("Não existe");
            }

            [HttpGet]
            public IActionResult PesquisarProdutoComFiltro([FromQuery] string nome, [FromQuery] bool? status, [FromQuery] string ordem, [FromQuery] int pagina, [FromQuery] int quantidade)
            {
                IQueryable<Produto> PesquisaDeProdutos = _produtoServices.PesquisarProdutoComFiltros(nome, status, ordem, pagina, quantidade);
                return Ok(PesquisaDeProdutos);
            }


            [HttpPut("{id}")]
            public IActionResult EditarProdutos(int id, [FromBody] UpDateProdutoDto produtoUpDateDto)
            {
                Result ResultadoEditarProduto = _produtoServices.EditarProduto(id, produtoUpDateDto);
                if (ResultadoEditarProduto == null) return NotFound();
                return NoContent();


            }

            [HttpDelete("{id}")]

            public IActionResult DeletarProduto(int id)
            {
                Result ResultadoDaExclusaoProduto = _produtoServices.DeletarProduto(id);

                if (ResultadoDaExclusaoProduto.IsFailed) return NotFound();
                return NoContent();
            }

        }
    }




//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            return Ok(await _produtosRepository.GetAllAsync());
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(int id)
//        {
//            var produtosx = await _produtosRepository.GetByIdAsync(id);
//            if (produtosx == null) return NotFound();
//            return Ok(produtosx);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Add(Produto produtos)
//        {
//            return Ok(await _produtosRepository.AddAsync(produtos));
//        }


//        [HttpDelete]
//        public async Task<IActionResult> Delete(int id)
//        {
//            await _produtosRepository.DeleteAsync(id);
//            return NoContent();
//        }


//        [HttpPut("{id}")]
//        public async Task<IActionResult> Update(int id, Produto produtos)
//        {
//            return Ok(await _produtosRepository.UpdateAsync(produtos));
//        }

//    }
//}


