using Api_DentalTec.Dtos;
using Api_DentalTec.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_DentalTec.Controllers
{
    [Route("pacientes")]
    [ApiController]
    public class PacienteController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Paciente> listaPacientes = new PacienteDAO().List();
                return Ok(listaPacientes);
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
                var paciente = new PacienteDAO().GetById(id);

                if (paciente == null)
                {
                    return NotFound();
                }

                return Ok(paciente);
            }
            catch (Exception)
            {
                return Problem("Ocorreram erros ao processar a solicitação.");
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] PacienteDTO item)
        {
            var paciente = new Paciente
            {
                Nome = item.Nome,
                Cpf = item.Cpf,
                Status = item.Status,
                Rg = item.Rg,
                Expedidor = item.Expedidor,
                DataNascimento = item.DataNascimento,
                EstadoCivil = item.EstadoCivil,
                Sexo = item.Sexo,
                Email = item.Email,
                Telefone = item.Telefone,
                Cep = item.Cep,
                Cidade = item.Cidade,
                Rua = item.Rua,
                Numero = item.Numero,
                Bairro = item.Bairro
            };

            try
            {
                var dao = new PacienteDAO();
                paciente.Id = dao.Insert(paciente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Created("", paciente);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PacienteDTO item)
        {
            try
            {
                var paciente = new PacienteDAO().GetById(id);

                if (paciente == null)
                {
                    return NotFound();
                }
                paciente.Nome = item.Nome;
                paciente.Cpf = item.Cpf;
                paciente.Status = item.Status;
                paciente.Rg = item.Rg;
                paciente.Expedidor = item.Expedidor;
                paciente.DataNascimento = item.DataNascimento;
                paciente.EstadoCivil = item.EstadoCivil;
                paciente.Sexo = item.Sexo;
                paciente.Email = item.Email;
                paciente.Telefone = item.Telefone;
                paciente.Cep = item.Cep;
                paciente.Cidade = item.Cidade;
                paciente.Rua = item.Rua;
                paciente.Numero = item.Numero;
                paciente.Bairro = item.Bairro;

                new PacienteDAO().Update(paciente);

                return Ok(paciente);
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
                var paciente = new PacienteDAO().GetById(id);

                if (paciente == null)
                {
                    return NotFound();
                }

                // Chame o método Delete da DAO
                new PacienteDAO().Delete(id);

                return Ok();
            }
            catch (Exception e)
            {
                return Problem($"Erro ao excluir o paciente: {e.Message}");
            }
        }




    }
}

