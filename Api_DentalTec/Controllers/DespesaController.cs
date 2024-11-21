using Api_DentalTec.Dtos;
using Api_DentalTec.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_DentalTec.Controllers
{
    [Route("despesas")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Despesa> listaDespesa = new DespesaDAO().List();
                return Ok(listaDespesa);
            }
            catch (Exception) 
            {
                return Problem($"Ocorreram erros ao processar a solicitação");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var despesa = new DespesaDAO().GetById(id);

                if (despesa == null)
                {
                    return NotFound();
                }

                return Ok(despesa);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação");
            }

        }
        [HttpPost]
        public IActionResult Post([FromBody] DespesaDTO item)
        {
            var despesa = new Despesa();

            despesa.Funcionario = item.Funcionario;
            despesa.Caixa = item.Caixa;
            despesa.Data = item.Data;
            despesa.Valor = item.Valor;
            despesa.Descricao = item.Descricao;

            try
            {
                var dao = new DespesaDAO();
                despesa.Id = dao.Insert(despesa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", despesa);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DespesaDTO item) 
        {
            try
            {
                var despesa = new DespesaDAO().GetById(id);

                if (despesa == null)
                {
                    return NotFound();
                }

                despesa.Funcionario = item.Funcionario;
                despesa.Caixa = item.Caixa;
                despesa.Data = item.Data;
                despesa.Valor = item.Valor;
                despesa.Descricao = item.Descricao;

                new DespesaDAO().Update(despesa);

                return Ok(despesa);
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
                var despesa = new DespesaDAO().GetById(id);

                if (despesa == null)
                {
                    return NotFound();
                }

                new DespesaDAO().Delete(despesa.Id);
                return Ok(despesa);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
