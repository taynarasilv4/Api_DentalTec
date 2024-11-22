using Api_DentalTec.Dtos;
using Api_DentalTec.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_DentalTec.Controllers
{
    [Route("agendas")]
    [ApiController]
    public class AgendaController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Agenda> listaAgendas = new AgendaDAO().List();
                return Ok(listaAgendas);
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
                var agenda = new AgendaDAO().GetById(id);

                if (agenda == null)
                {
                    return NotFound();
                }

                return Ok(agenda);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AgendaDTO item)
        {
            var agenda = new Agenda
            {
                NomeAgenda = item.NomeAgenda,
                ProfissionalAgenda = item.ProfissionalAgenda,
                DataAgenda = item.DataAgenda,
                HoraAgenda = item.HoraAgenda
            };

            try
            {
                var dao = new AgendaDAO();
                agenda.Id = dao.Insert(agenda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", agenda);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AgendaDTO item)
        {
            try
            {
                var agenda = new AgendaDAO().GetById(id);

                if (agenda == null)
                {
                    return NotFound();
                }

                agenda.NomeAgenda = item.NomeAgenda;
                agenda.ProfissionalAgenda = item.ProfissionalAgenda;
                agenda.DataAgenda = item.DataAgenda;
                agenda.HoraAgenda = item.HoraAgenda;

                new AgendaDAO().Update(agenda);

                return Ok(agenda);
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
                var agenda = new AgendaDAO().GetById(id);

                if (agenda == null)
                {
                    return NotFound();
                }

                // Chame o método Delete da DAO
                new AgendaDAO().Delete(id);

                return Ok();
            }
            catch (Exception e)
            {
                return Problem($"Erro ao excluir a Agenda: {e.Message}");
            }
        }


    }


}





