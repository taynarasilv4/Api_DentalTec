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
        [HttpGet] // Listagem de todos os serviços
        public IActionResult Get()
        {
            try
            {
                List<Servico> listaServicos = new ServicoDAO().List();

                return Ok(listaServicos);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação.");
            }
        }

        [HttpGet("{id}")] // Busca por ID
        public IActionResult GetById(int id)
        {
            try
            {
                var servico = new ServicoDAO().GetById(id);

                if (servico == null)
                {
                    return NotFound("Serviço não encontrado.");
                }

                return Ok(servico);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação.");
            }
        }

        [HttpPost] // Criar um novo serviço
        public IActionResult Post([FromBody] ServicoDTO item)
        {
            var servico = new Servico();

            servico.NomeServico = item.NomeServico;
            servico.ProfissionalEspecializado = item.ProfissionalEspecializado;
            servico.Descricao = item.Descricao;

            try
            {
                var dao = new ServicoDAO();
                servico.Id = dao.Insert(servico);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar o serviço: {ex.Message}");
            }

            return Created("", servico);
        }

        [HttpPut("{id}")] // Atualizar um serviço existente
        public IActionResult Put(int id, [FromBody] ServicoDTO item)
        {
            try
            {
                var servico = new ServicoDAO().GetById(id);

                if (servico == null)
                {
                    return NotFound("Serviço não encontrado.");
                }

                servico.NomeServico = item.NomeServico;
                servico.ProfissionalEspecializado = item.ProfissionalEspecializado;
                servico.Descricao = item.Descricao;

                new ServicoDAO().Update(servico);

                return Ok(servico);
            }
            catch (Exception ex)
            {
                return Problem($"Erro ao atualizar o serviço: {ex.Message}");
            }
        }

        [HttpDelete("{id}")] // Excluir um serviço
        public IActionResult Delete(int id)
        {
            try
            {
                var servico = new ServicoDAO().GetById(id);

                if (servico == null)
                {
                    return NotFound("Serviço não encontrado.");
                }

                new ServicoDAO().Delete(servico.Id);

                return Ok(servico); // Retorna o serviço excluído
            }
            catch (Exception ex)
            {
                return Problem($"Erro ao excluir o serviço: {ex.Message}");
            }
        }
    }
}
