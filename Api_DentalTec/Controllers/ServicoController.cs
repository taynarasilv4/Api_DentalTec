using Api_DentalTec.Dtos;
using Api_DentalTec.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_DentalTec.Controllers
{
    [Route("servicos")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        List<Servico> listaServico = new List<Servico>();

        public ServicoController()
        {
            var servico1 = new Servico()
            {
                Id = 1,
                Servicoo = "x",
                ProfissionalEspecializado = "Sthefany Lorrany Gomes Silva",
                Descricao = "y"
            };

            listaServico.Add(servico1);
        }

        [HttpGet] //listagem
        public IActionResult Get()
        {
            return Ok(listaServico);
        }

        [HttpGet("{id}")] //listagem = busca pelo id
        public IActionResult GetById(int id)
        {
            var servico = listaServico.Where(item => item.Id == id).FirstOrDefault(); /*fazendo busca do servico*/

            if (servico == null) /*verifica se existe*/
            {
                return NotFound();
            }

            return Ok(servico);
        }

        [HttpPost] //criar um registro
        public IActionResult Post([FromBody] ServicoDTO item)
        {
            var contador = listaServico.Count();

            var servico = new Servico();

            servico.Id = contador + 1;
            servico.Servicoo = item.Servicoo;
            servico.ProfissionalEspecializado = item.ProfissionalEspecializado;
            servico.Descricao = item.Descricao;

            listaServico.Add(servico);

            return StatusCode(StatusCodes.Status201Created, servico);
        }

        [HttpPut("{id}")] //atualizar um registro
        public IActionResult Put(int id, [FromBody] ServicoDTO item)
        {
            var servico = listaServico.Where(item => item.Id == id).FirstOrDefault();/*fazendo busca do servico*/

            if (servico == null) /*verifica se existe*/
            {
                return NotFound();
            }

            servico.Servicoo = item.Servicoo;
            servico.ProfissionalEspecializado = item.ProfissionalEspecializado;
            servico.Descricao = item.Descricao;

            return Ok(servico);
        }

        [HttpDelete("{id}")] //excluir um registro
        public IActionResult Delete(int id)
        {
            var servico = listaServico.Where(item => item.Id == id).FirstOrDefault();/*fazendo busca do servico*/

            if (servico == null) /*verifica se existe*/
            {
                return NotFound();
            }

            listaServico.Remove(servico);

            /*return NoContent(); /*status code 204 e você não retorna nenhuma informação*/
            return Ok(servico); /*mostra o servico que você excluiu*/
        }
    }
}

