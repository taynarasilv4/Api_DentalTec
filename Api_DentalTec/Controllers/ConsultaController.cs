using Api_DentalTec.Dtos;
using Api_DentalTec.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
                var listaConsultas = new ConsultaDAO().List();

                if (listaConsultas == null || listaConsultas.Count == 0)
                {
                    return NotFound("Nenhuma consulta encontrada.");
                }

                return Ok(listaConsultas);
            }
            catch (Exception ex)
            {
                return Problem($"Erro ao obter consultas: {ex.Message}");
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
                    return NotFound($"Consulta com ID {id} não encontrada.");
                }

                return Ok(consulta);
            }
            catch (Exception ex)
            {
                return Problem($"Erro ao obter a consulta: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ConsultaDTO item)
        {
            try
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

                consulta.Id = new ConsultaDAO().Insert(consulta);

                return CreatedAtAction(nameof(GetById), new { id = consulta.Id }, consulta);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar consulta: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ConsultaDTO item)
        {
            try
            {
                var consulta = new ConsultaDAO().GetById(id);

                if (consulta == null)
                {
                    return NotFound($"Consulta com ID {id} não encontrada.");
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
            catch (Exception ex)
            {
                return Problem($"Erro ao atualizar consulta: {ex.Message}");
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
                    return NotFound($"Consulta com ID {id} não encontrada.");
                }

                new ConsultaDAO().Delete(id);

                return Ok($"Consulta com ID {id} excluída com sucesso.");
            }
            catch (Exception ex)
            {
                return Problem($"Erro ao excluir consulta: {ex.Message}");
            }
        }
    }
}


