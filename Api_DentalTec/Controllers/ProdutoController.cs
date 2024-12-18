﻿using Api_DentalTec.Dtos;
using Api_DentalTec.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_DentalTec.Controllers
{
    [Route("produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Produto> listaProdutos = new ProdutoDAO().List();
                return Ok(listaProdutos);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var produto = new ProdutoDAO().GetById(id);

                if (produto == null)
                {
                    return NotFound();
                }

                return Ok(produto);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoDTO item)
        {
            var produto = new Produto
            {
                Nomeproduto = item.Nomeproduto,
                CodigoBarra = item.CodigoBarra,
                DataFabricacao = item.DataFabricacao,
                DataValidade = item.DataValidade,
                Valor = item.Valor
            };

            try
            {
                var dao = new ProdutoDAO();
                produto.Id = dao.Insert(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", produto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProdutoDTO item)
        {
            try
            {
                var produto = new ProdutoDAO().GetById(id);

                if (produto == null)
                {
                    return NotFound();
                }

                produto.Nomeproduto = item.Nomeproduto;
                produto.CodigoBarra = item.CodigoBarra;
                produto.DataFabricacao = item.DataFabricacao;
                produto.DataValidade = item.DataValidade;
                produto.Valor = item.Valor;

                new ProdutoDAO().Update(produto);

                return Ok(produto);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var produto = new ProdutoDAO().GetById(id);

                if (produto == null)
                {
                    return NotFound();
                }

                new ProdutoDAO().Delete(id);

                return Ok();
            }
            catch (Exception e)
            {
                return Problem($"Erro ao excluir o produto: {e.Message}");
            }
        }
    }
}
