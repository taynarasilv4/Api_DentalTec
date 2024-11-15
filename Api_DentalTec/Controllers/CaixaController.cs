using Api_DentalTec.Dtos;
using Api_DentalTec.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_DentalTec.Controllers
{
    [Route("caixa")]
    [ApiController]
    public class CaixaController : ControllerBase
    {
        List<Caixa> listaCaixa = new List<Caixa>();

        public CaixaController()
        {
            var caixa1 = new Caixa()
            {
                Id = 1,
                Funcionario = "Natalia Pereira",
                TotalEntrada = 200.00,
                TotalSaida = 50.00,
                ValorTotal = 1000.00,
                ValorInicial = 0,
                TipoPagamento = "Dinheiro"

            };


            listaCaixa.Add(caixa1);
        }

        [HttpGet] 
        public IActionResult Get()
        {
            return Ok(listaCaixa);
        }

        [HttpGet("{id}")] 
        public IActionResult GetById(int id)
        {
            var caixa = listaCaixa.Where(item => item.Id == id).FirstOrDefault(); 

            if (caixa == null) 
            {
                return NotFound();
            }

            return Ok(caixa);
        }

        [HttpPost] 
        public IActionResult Post([FromBody] CaixaDTO item)
        {

            var contador = listaCaixa.Count();
            var caixa = new Caixa();

            caixa.Id = contador + 1;
            caixa.Funcionario = item.Funcionario;
            caixa.TotalEntrada = item.TotalEntrada;
            caixa.TotalSaida = item.TotalSaida;
            caixa.ValorTotal = item.ValorTotal;
            caixa.ValorInicial = item.ValorInicial;
            caixa.TipoPagamento = item.TipoPagamento;

            listaCaixa.Add(caixa);

            return StatusCode(StatusCodes.Status201Created, caixa);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CaixaDTO item)
        {
            var caixa = listaCaixa.Where(item => item.Id == id).FirstOrDefault();

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



            return Ok(caixa);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var caixa = listaCaixa.Where(item => item.Id == id).FirstOrDefault();

            if (caixa == null)
            {
                return NotFound();
            }

            listaCaixa.Remove(caixa);


            return Ok(caixa);
        }

    }
}