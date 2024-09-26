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
        private List<Consulta> listaConsultas = new List<Consulta>();

        public ConsultaController()
        {
            // Exemplo de consulta
            var consulta1 = new Consulta()
            {
                Id = 1,
                NomePaciente = "João da Silva",
                DataNascimento = new DateTime(1985, 5, 15),
                Sexo = "Masculino",
                Endereco = "Rua das Flores, 123",
                Telefone = "(11) 98765-4321",
                DataConsulta = new DateTime(2024, 9, 19),
                HoraConsulta = new TimeSpan(14, 0, 0),
                NomeMedico = "Dr. Carlos Oliveira",
                Especialidade = "Clínica Geral",
                MotivoConsulta = "Dor no peito",
                HistoricoSaude = "Sem doenças pré-existentes",
                Sintomas = "Dor no peito e falta de ar",
                ExameFisico = "Pressão arterial normal",
                Diagnostico = "Avaliação cardíaca necessária",
                TratamentoOrientacoes = "Solicitar exames e repouso",
                Observacoes = "Paciente ansioso"
            };

            listaConsultas.Add(consulta1);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listaConsultas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var consulta = listaConsultas.FirstOrDefault(item => item.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }
            return Ok(consulta);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ConsultaDTO item)
        {
            var contador = listaConsultas.Count();

            var consulta = new Consulta();

            consulta.NomePaciente = item.NomePaciente;
            consulta.DataNascimento = item.DataNascimento;
            consulta.Sexo = item.Sexo;
            consulta.Endereco = item.Endereco;
            consulta.Telefone = item.Telefone;
            consulta.DataConsulta = item.DataConsulta;
            consulta.HoraConsulta = item.HoraConsulta;
            consulta.NomeMedico = item.NomeMedico;
            consulta.MotivoConsulta = item.Especialidade;
            consulta.HistoricoSaude = item.MotivoConsulta;
            consulta.HistoricoSaude = item.HistoricoSaude;
            consulta.Sintomas = item.Sintomas;
            consulta.ExameFisico = item.ExameFisico;
            consulta.Diagnostico = item.Diagnostico;
            consulta.TratamentoOrientacoes = item.TratamentoOrientacoes;
            consulta.Observacoes = item.Observacoes;

            listaConsultas.Add(consulta);
            return StatusCode(StatusCodes.Status201Created, consulta);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ConsultaDTO item)
        {
            var consulta = listaConsultas.FirstOrDefault(c => c.Id == id);
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

            return Ok(consulta);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var consulta = listaConsultas.FirstOrDefault(c => c.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            listaConsultas.Remove(consulta);
            return Ok(consulta);
        }
    }
}


