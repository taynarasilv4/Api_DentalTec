using Api_DentalTec.Dtos;
using Api_DentalTec.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_DentalTec.Controllers
{
    [Route("consultas")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Consulta> listaConsulta = new ConsultaDAO().List();
                return Ok(listaConsulta);
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
                var consulta = new ConsultaDAO().GetById(id);

                if (consulta == null)
                {
                    return NotFound();
                }

                return Ok(consulta);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ConsultaDTO item)
        {
            var consulta = new Consulta
            {
                NomePaciente = item.NomePaciente,
                DataNascimento = item.DataNascimento,
                Sexo = item.Sexo,
                Endereco = item.Endereco,
                Telefone = item.Telefone,
                DataConsulta = item.DataConsulta,
                HoraConsulta = item.HoraConsulta,
                NomeMedico = item.NomeMedico,
                Especialidade = item.Especialidade,
                MotivoConsulta = item.MotivoConsulta,
                HistoricoSaude = item.HistoricoSaude,
                Sintomas = item.Sintomas,
                ExameFisico = item.ExameFisico,
                Diagnostico = item.Diagnostico,
                TratamentoOrientacoes = item.TratamentoOrientacoes,
                Observacoes = item.Observacoes
            };

            try
            {
                var dao = new ConsultaDAO();
                consulta.Id = dao.Insert(consulta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", consulta);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ConsultaDTO item)
        {
            try
            {
                var consulta = new ConsultaDAO().GetById(id);

                if (consulta == null)
                {
                    return NotFound();
                }

                consulta.NomePaciente = item.NomePaciente;
                consulta.DataNascimento = item.DataNascimento;
                consulta.Sexo = item.Sexo;
                consulta.Endereco = item.Endereco;
                consulta.Telefone = item.Telefone;
                consulta.DataConsulta = item.DataConsulta;
                consulta.HoraConsulta = item.HoraConsulta;
                consulta.NomeMedico = item.NomeMedico;
                consulta.Especialidade = item.Especialidade;
                consulta.MotivoConsulta = item.MotivoConsulta;
                consulta.HistoricoSaude = item.HistoricoSaude;
                consulta.Sintomas = item.Sintomas;
                consulta.ExameFisico = item.ExameFisico;
                consulta.Diagnostico = item.Diagnostico;
                consulta.TratamentoOrientacoes = item.TratamentoOrientacoes;
                consulta.Observacoes = item.Observacoes;



                new ConsultaDAO().Update(consulta);

                return Ok(consulta);
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
                var consulta = new ConsultaDAO().GetById(id);

                if (consulta == null)
                {
                    return NotFound();
                }

                // Chame o método Delete da DAO
                new ConsultaDAO().Delete(id);

                return Ok();
            }
            catch (Exception e)
            {
                return Problem($"Erro ao excluir o consulta: {e.Message}");
            }
        }
    }
}




































