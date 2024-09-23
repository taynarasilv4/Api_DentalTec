using Api_DentalTec.Dtos;
using Api_DentalTec.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_DentalTec.Controllers
{
    [Route("orcamentos")]
    [ApiController]
    public class OrcamentoController : ControllerBase
    {
        
            List<Orcamento> listaOrcamento = new List<Orcamento>();
            public OrcamentoController()
            {
                var orcamento1 = new Orcamento()
                {
                    Id = 1,
                    Nome = "Renato",
                    Data_Nasc = new DateTime(2006, 06, 26),
                    Cpf = "026.662.922-90",
                    Rua = "Avenida Ji-Paraná",
                    Numero = 1050,
                    Bairro = "Rondônia",
                    Cidade = "Cacoal",
                    Email = "Renato@gmail.com",
                    Contato = "(99) 99999-9999",
                    Profissional = "DR Antônio",
                    Data = new DateTime(2024, 09, 16),
                    Servico = "Endodontia",
                    Regiao = "Boca",
                    Valor_Unit = "R$ 1.500,00"
                };

                listaOrcamento.Add(orcamento1);
            }

            [HttpGet]
            public IActionResult Get()
            {
                return Ok(listaOrcamento);
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var orcamento = listaOrcamento.Where(item => item.Id == id).FirstOrDefault();

                if (orcamento == null)
                {
                    return NotFound();
                }

                return Ok(orcamento);
            }

            [HttpPost]
            public IActionResult Post([FromBody] OrcamentoDTO item)
            {

                if (!Validations.ValidaCPF.ValidaCpf(item.Cpf))//se false
                {
                    return BadRequest("CPF inválido.");
                }


                var contador = listaOrcamento.Count();

                var orcamento = new Orcamento();

                orcamento.Id = contador + 1;
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

                listaOrcamento.Add(orcamento);

                return StatusCode(StatusCodes.Status201Created, orcamento);
            }
            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] OrcamentoDTO item)
            {
                var orcamento = listaOrcamento.Where(item => item.Id == id).FirstOrDefault();
                if (orcamento == null)
                {
                    return NotFound();
                }

                if (!Validations.ValidaCPF.ValidaCpf(item.Cpf))
                {
                    return BadRequest("CPF inválido.");
                }


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

                return Ok(orcamento);
            }
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var orcamento = listaOrcamento.Where(item => item.Id == id).FirstOrDefault();

                if (orcamento == null)
                {
                    return NotFound();
                }

                listaOrcamento.Remove(orcamento);

                return Ok(orcamento);
            }

    }
}
