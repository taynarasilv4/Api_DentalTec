using Api_DentalTec.Dtos;
using Api_DentalTec.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Api_DentalTec.Controllers
{
    [Route("despesas")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        List<Despesa> listaDespesa = new List<Despesa>();
        public DespesaController()
        {
            var despesa1 = new Despesa()
            {
                Id = 1,
                Funcionario = "Taynara Da Silva Rodrigues",
                Caixa = "x",
                Data = new DateTime(2006, 5, 21),
                Valor = 100,
                Descricao = "y"
            };

            listaDespesa.Add(despesa1);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listaDespesa);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var despesa = listaDespesa.Where(item => item.Id == id).FirstOrDefault();

            if (despesa == null)
            {
                return NotFound();
            }

            return Ok(despesa);
        }
        [HttpPost]
        public IActionResult Post([FromBody] DespesaDTO item)
        {
            var contador = listaDespesa.Count();

            var despesa = new Despesa();

            despesa.Id = contador + 1;
            despesa.Funcionario = item.Funcionario;
            despesa.Caixa = item.Caixa;
            despesa.Data = item.Data;
            despesa.Valor = item.Valor;
            despesa.Descricao = item.Descricao;

            listaDespesa.Add(despesa);

            return StatusCode(StatusCodes.Status201Created, despesa);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DespesaDTO item) 
        {
            var despesa = listaDespesa.Where(item => item.Id == id).FirstOrDefault();

            if (despesa == null)
            {
                return NotFound();
            }

            despesa.Funcionario = item.Funcionario;
            despesa.Caixa = item.Caixa;
            despesa.Data = item.Data;
            despesa.Valor = item.Valor;
            despesa.Descricao = item.Descricao;

            return Ok(despesa);
        }
        [HttpDelete("{id}")] 
        public IActionResult Delete(int id)
        {
            var despesa = listaDespesa.Where(item => item.Id == id).FirstOrDefault();

            if (despesa == null) 
            {
                return NotFound();
            }

            listaDespesa.Remove(despesa);

            return Ok(despesa); 
        }
    }
}
