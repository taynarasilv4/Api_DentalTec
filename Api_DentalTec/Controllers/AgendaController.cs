using Api_DentalTec.Dtos;
using Api_DentalTec.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_DentalTec.Controllers
{

    [Route("agendas")]
    [ApiController]

    public class AgendaController : ControllerBase
    {
        List<Agenda> listaAgenda = new List<Agenda>();

        public AgendaController()
        {
            var agenda1 = new Agenda()
            {
                Id = 1,
                NomeAgenda = "Natalia Pereira",
                ProfissionalAgenda = "Larissa Emanuela",
                DataAgenda = new DateTime(2024, 9, 17),
                HoraAgenda = new TimeSpan(13, 00, 00)

            };

            listaAgenda.Add(agenda1);
        }

        [HttpGet] //listagem
        public IActionResult Get()
        {
            return Ok(listaAgenda);
        }

        [HttpGet("{id}")] //listagem = busca pelo id
        public IActionResult GetById(int id)
        {
            var agenda = listaAgenda.Where(item => item.Id == id).FirstOrDefault(); /*fazendo busca na agenda*/

            if (agenda == null) /*verifica se existe*/
            {
                return NotFound();
            }

            return Ok(agenda);
        }

        [HttpPost] //criar um registro
        public IActionResult Post([FromBody] AgendaDTO item)
        {

            var contador = listaAgenda.Count();
            var agenda = new Agenda();

            agenda.Id = contador + 1;
            agenda.NomeAgenda = item.NomeAgenda;
            agenda.ProfissionalAgenda = item.ProfissionalAgenda;
            agenda.DataAgenda = item.DataAgenda;
            agenda.HoraAgenda = item.HoraAgenda;

            listaAgenda.Add(agenda);

            return StatusCode(StatusCodes.Status201Created, agenda);
        }

        [HttpPut("{id}")] //atualizar um registro
        public IActionResult Put(int id, [FromBody] AgendaDTO item)
        {
            var agenda = listaAgenda.Where(item => item.Id == id).FirstOrDefault();/*fazendo busca*/

            if (agenda == null) /*verifica se existe*/
            {
                return NotFound();
            }

            agenda.NomeAgenda = item.NomeAgenda;
            agenda.ProfissionalAgenda = item.ProfissionalAgenda;
            agenda.DataAgenda = item.DataAgenda;
            agenda.HoraAgenda = item.HoraAgenda;


            return Ok(agenda);
        }

        [HttpDelete("{id}")] //excluir um registro
        public IActionResult Delete(int id)
        {
            var agenda = listaAgenda.Where(item => item.Id == id).FirstOrDefault();

            if (agenda == null) /*verifica se existe*/
            {
                return NotFound();
            }

            listaAgenda.Remove(agenda);

            /*return NoContent(); /*status code 204 e você não retorna nenhuma informação*/
            return Ok(agenda);
        }

    }


}

