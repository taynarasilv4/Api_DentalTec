﻿using Api_DentalTec.Dtos;
using Api_DentalTec.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_DentalTec.Controllers
{
    [Route("Caixa")]
    [ApiController]
    public class CaixaController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Caixa> listaCaixa = new CaixaDAO().List();
                return Ok(listaCaixa);
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
                var caixa = new CaixaDAO().GetById(id);

                if (caixa == null)
                {
                    return NotFound();
                }

                return Ok(caixa);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CaixaDTO item)
        {
            var caixa = new Caixa
            {

                Funcionario = item.Funcionario,
                TotalEntrada = item.TotalEntrada,
                TotalSaida = item.TotalSaida,
                ValorTotal = item.ValorTotal,
                ValorInicial = item.ValorInicial,
                TipoPagamento = item.TipoPagamento



            };

            try
            {
                var dao = new CaixaDAO();
                caixa.Id = dao.Insert(caixa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", caixa);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CaixaDTO item)
        {
            try
            {
                var caixa = new CaixaDAO().GetById(id);

                if (caixa == null)
                {
                    return NotFound();
                }


                caixa.Funcionario = item.Funcionario;
                caixa.TotalEntrada = item.TotalEntrada;
                caixa.TotalSaida = item.TotalSaida;
                caixa.ValorTotal = item.ValorTotal;
                caixa.ValorInicial = item.ValorInicial;
                caixa.TipoPagamento = item.TipoPagamento;



                new CaixaDAO().Update(caixa);

                return Ok(caixa);
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
                var caixa = new CaixaDAO().GetById(id);

                if (caixa == null)
                {
                    return NotFound();
                }

                // Chame o método Delete da DAO
                new CaixaDAO().Delete(id);

                return Ok();
            }
            catch (Exception e)
            {
                return Problem($"Erro ao excluir o caixa: {e.Message}");
            }
        }
    }
}

