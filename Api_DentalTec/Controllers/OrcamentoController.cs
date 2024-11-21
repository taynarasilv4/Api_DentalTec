using Api_DentalTec.Dtos;
using Api_DentalTec.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_DentalTec.Controllers
{
    [Route("orcamentos")]
    [ApiController]
    public class OrcamentoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Orcamento> listaOrcamentos = new OrcamentoDAO().List();

            return Ok(listaOrcamentos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrcamentoDTO item)
        {

            var orcamento = new Orcamento();

            orcamento.Nome = item.Nome;
            orcamento.Data_Nasc = item.Data_Nasc;
            orcamento.Cpf = item.Cpf;
            orcamento.Rua = item.Rua;
            orcamento.Numero = item.Numero;
            orcamento.Bairro = item.Bairro;
            orcamento.Cidade = item.Cidade;
            orcamento.Email = item.Email;
            orcamento.Contato = item.Contato;
            orcamento.Profissional = item.Profissional;
            orcamento.Data = item.Data;
            orcamento.Servico = item.Servico;
            orcamento.Regiao = item.Regiao;
            orcamento.Valor_Unit = item.Valor_Unit;
            try
            {
                var dao = new OrcamentoDAO();
                orcamento.Id = dao.Insert(orcamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Created("", orcamento);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            try
            {
                var orcamento = new OrcamentoDAO().GetById(id);

                if (orcamento == null)
                {
                    return NotFound();
                }

                return Ok(orcamento);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrcamentoDTO item)
        {
            try
            {
                var orcamento = new OrcamentoDAO().GetById(id);

                if (orcamento == null)
                {
                    return NotFound();
                }

                orcamento.Nome = item.Nome;
                orcamento.Data_Nasc = item.Data_Nasc;
                orcamento.Cpf = item.Cpf;
                orcamento.Rua = item.Rua;
                orcamento.Numero = item.Numero;
                orcamento.Bairro = item.Bairro;
                orcamento.Cidade = item.Cidade;
                orcamento.Email = item.Email;
                orcamento.Contato = item.Contato;
                orcamento.Profissional = item.Profissional;
                orcamento.Data = item.Data;
                orcamento.Servico = item.Servico;
                orcamento.Regiao = item.Regiao;
                orcamento.Valor_Unit = item.Valor_Unit;

                new OrcamentoDAO().Update(orcamento);

                return Ok(orcamento);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
                // return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var orcamento = new OrcamentoDAO().GetById(id);

                if (orcamento == null)
                {
                    return NotFound();
                }

                new OrcamentoDAO().Delete(orcamento.Id);

                return Ok();
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }

    }
}

